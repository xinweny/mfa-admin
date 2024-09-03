using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Core.Pagination;
using MfaApi.Modules.Membership;
using MfaApi.Core.Constants;

namespace MfaApi.Modules.Member;

public class MemberRepository: IMemberRepository {
    private readonly MfaDbContext _context;
    private readonly IValidator<MemberModel> _memberValidator;
    private readonly IValidator<MembershipModel> _membershipValidator;

    public MemberRepository(
        MfaDbContext context,
        IValidator<MemberModel> memberValidator,
        IValidator<MembershipModel> membershipValidator
    ) {
        _context = context;
        _memberValidator = memberValidator;
        _membershipValidator = membershipValidator;
    }

    public async Task<MemberModel> GetMemberById(Guid id) {
        var member = await _context.Members
            .AsNoTracking()
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null)
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Members : null)
            .Where(m => m.Id == id)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Member not found.");

        return member;
    }

    public async Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req) {
        var query = _context.Members
            .AsNoTracking()
            .AsQueryable();

        query = query
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null);
        
        if (!string.IsNullOrEmpty(req.Query)) {
            query = query.Where(MemberUtils.GetFullNameFilter(req.Query));
        }

        if (req.IsMississaugaResident != null) {
            query = query.Where(m => 
                m.Membership != null
                && m.Membership.Address != null
                && EF.Functions.ILike(m.Membership.Address.City, "Mississauga")
            );
        }

        if (req.JoinedFrom != null) {
            query = query.Where(m => m.JoinedDate >= DateOnly.FromDateTime((DateTime) req.JoinedFrom));
        }

        if (req.JoinedTo != null) {
            query = query.Where(m => m.JoinedDate <= DateOnly.FromDateTime((DateTime) req.JoinedTo));
        }

        if (req.SortFirstName.Equals(SortOrder.Ascending)) {
            query = query.OrderBy(m => m.FirstName);
        } else if (req.SortFirstName.Equals(SortOrder.Descending)) {
            query = query.OrderByDescending(m => m.FirstName);
        }

        if (req.SortLastName.Equals(SortOrder.Ascending)) {
            query = query.OrderBy(m => m.LastName);
        } else if (req.SortLastName.Equals(SortOrder.Descending)) {
            query = query.OrderByDescending(m => m.LastName);
        }

        if (req.SortJoinedDate.Equals(SortOrder.Ascending)) {
            query = query.OrderBy(m => m.JoinedDate);
        } else if (req.SortJoinedDate.Equals(SortOrder.Descending)) {
            query = query.OrderByDescending(m => m.JoinedDate);
        }

        query.Paginate(req);

        return await query.ToListAsync();
    }

    public async Task CreateMember(MemberModel member) {
        var membership = await _context.Memberships
            .Include(m => m.Members)
            .Where(m => m.Id == member.MembershipId)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Membership not found.");

        membership.Members?.Add(member);

        _membershipValidator.ValidateAndThrow(membership);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateMember(MemberModel member, UpdateMemberRequest req) {
        member.UpdatedAt = DateTime.UtcNow;

        _context.Members.Entry(member).CurrentValues.SetValues(req);

        _memberValidator.ValidateAndThrow(member);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMember(MemberModel member) {
        var membership = member.Membership
            ?? throw new KeyNotFoundException("Membership not found.");

        membership.Members?.Remove(member);

        _membershipValidator.ValidateAndThrow(membership);

        await _context.SaveChangesAsync();
    }
}