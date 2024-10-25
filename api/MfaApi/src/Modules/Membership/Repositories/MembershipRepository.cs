using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Core.Sort;
using MfaApi.Core.Constants;
using System.Diagnostics;

namespace MfaApi.Modules.Membership;

public class MembershipRepository: IMembershipRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<MembershipModel> _validator;

    public MembershipRepository(MfaDbContext context, IValidator<MembershipModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateMembership(MembershipModel membership) {
        _validator.ValidateAndThrow(membership);

        _context.Memberships.Add(membership);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteMembership(MembershipModel membership) {
        _context.Memberships.Remove(membership);

        await _context.SaveChangesAsync();
    }

    public async Task<MembershipModel> GetMembershipById(Guid id) {
        var membership = await _context.Memberships
            .Where(m => m.Id == id)
            .Include(m => m.Address)
            .Include(m => m.Members)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Membership not found.");

        return membership;
    }
    
    public IQueryable<MembershipModel> GetMembershipsQuery(GetMembershipsRequest req) {
        var query = _context.Memberships
            .AsNoTracking()
            .AsQueryable();

        query = query
            .Include(m => m.Address)
            .Include(m => m.Members)
            .Include(m => m.Dues.Where(d => d.Year == req.YearPaid));

        if (req.IsInactive != null) {
            query = query.Where(m => (bool) req.IsInactive
                ? !m.IsActive
                : m.IsActive);
        }
        
        if (!string.IsNullOrEmpty(req.Query)) {
            query = query.Where(m => m.Members
                .AsQueryable()
                .Any(m => EF.Functions.ILike(m.FirstName + m.LastName, $"%{req.Query.Replace(" ", "")}%"))
            );
        }

        if (req.MembershipType != null) {
            query = query.Where(m => m.MembershipType.Equals(req.MembershipType));
        }

        if (req.HasPaid != null) {
            query = query.Where(m => (bool) req.HasPaid
                ? m.Dues.Count(d => d.Year == req.YearPaid) > 0
                : m.Dues.Count(d => d.Year == req.YearPaid) == 0);
        }

        if (req.SinceFrom != null) {
            query = query.Where(b => b.StartDate >= DateOnly.FromDateTime((DateTime) req.SinceFrom));
        }
        if (req.SinceTo != null) {
            query = query.Where(b => b.StartDate <= DateOnly.FromDateTime((DateTime) req.SinceTo));
        }

        query = query.Sort(m => m.StartDate, req.SortStartDate);
        
        return query;
    }

    public async Task UpdateMembership(MembershipModel membership, UpdateMembershipRequest req) {
        membership.UpdatedAt = DateTime.UtcNow;

        _context.Memberships.Entry(membership).CurrentValues.SetValues(new {
            req.MembershipType,
            StartDate = DateOnly.FromDateTime(req.StartDate),
            req.IsActive,
        });

        _validator.ValidateAndThrow(membership);
        
        await _context.SaveChangesAsync();
    }

    public async Task<GetMembershipDueTotalsResponse?> GetMembershipDueTotals(GetMembershipDueTotalsRequest req) {
        var query = _context.Memberships
            .AsNoTracking()
            .AsQueryable()
            .Include(m => m.Dues)
            .Where(m => m.IsActive)
            .Where(m => m.StartDate.Year <= req.DueYear)
            .GroupBy(m => true)
            .Select((g) => new GetMembershipDueTotalsResponse {
                TotalDues = g.Sum(m => m.MembershipType == MembershipType.Single
                    ? MfaConstants.SingleMembershipCost
                    : (m.MembershipType == MembershipType.Family
                        ? MfaConstants.FamilyMembershipCost
                        : 0
                    )),
                TotalDuesPaid = g.Sum(m => m.Dues.Where(d => d.Year == req.DueYear).Count() == 0
                    ? 0
                    : m.Dues.First().AmountPaid),
            });

        return await query.SingleOrDefaultAsync();
    }

    public async Task<GetMembershipTypeCountsResponse?> GetMembershipTypeCounts() {
        var query = _context.Memberships
            .AsNoTracking()
            .AsQueryable()
            .Where(m => m.IsActive)
            .GroupBy(m => true)
            .Select(g => new GetMembershipTypeCountsResponse {
                Single = g.Count(m => m.MembershipType == MembershipType.Single),
                    Family = g.Count(m => m.MembershipType == MembershipType.Family),
                    Honorary = g.Count(m => m.MembershipType == MembershipType.Honorary),
            });

        return await query.SingleOrDefaultAsync();
    }
}