using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Common.Constants;
using MfaApi.Database;
using MfaApi.Modules.Member;

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
    
    public async Task<IEnumerable<MembershipModel>> GetMemberships(GetMembershipsRequest req) {
        var query = _context.Memberships.AsQueryable();

        query = query
            .Include(m => m.Address)
            .Include(m => m.Members)
            .Include(m => req.YearPaid == null
                ? m.Dues
                : m.Dues.Where(d => d.Year == req.YearPaid)
            );
        
        if (!string.IsNullOrEmpty(req.Query)) {
            var fullNameFilter = MemberUtils.GetFullNameFilter(req.Query);

            query = query.Where(
                membership => membership.Members
                    .AsQueryable()
                    .Any(fullNameFilter));
        }

        if (SortOrder.Ascending.Equals(req.SortStartDate)) {
            query = query.OrderBy(m => m.StartDate);
        } else if (SortOrder.Descending.Equals(req.SortStartDate)) {
            query = query.OrderByDescending(m => m.StartDate);
        }
        
        return await query.ToListAsync();
    }

    public async Task UpdateMembership(MembershipModel membership, UpdateMembershipRequest req) {
        membership.UpdatedAt = DateTime.UtcNow;

        _context.Memberships.Entry(membership).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(membership);
        
        await _context.SaveChangesAsync();
    }
}