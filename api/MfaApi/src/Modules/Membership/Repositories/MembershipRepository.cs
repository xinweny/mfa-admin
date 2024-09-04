using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Core.Sort;

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
            .AsNoTracking()
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

        _context.Memberships.Entry(membership).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(membership);
        
        await _context.SaveChangesAsync();
    }
}