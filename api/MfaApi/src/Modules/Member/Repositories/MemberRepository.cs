using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Modules.Membership;
using MfaApi.Core.Sort;

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
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null)
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Members : null)
            .Where(m => m.Id == id)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Member not found.");

        return member;
    }

    public IQueryable<MemberModel> GetMembersQuery(GetMembersRequest req) {
        var query = _context.Members
            .AsNoTracking()
            .AsQueryable();

        query = query
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null);

        if (req.IsInactive != null) {
            query = query.Where(m => (bool) req.IsInactive
                ? !m.Membership!.IsActive
                : m.Membership!.IsActive);
        }
        
        if (!string.IsNullOrEmpty(req.Query)) {
            query = query.Where(m => EF.Functions.ILike(m.FirstName + m.LastName, $"%{req.Query.Replace(" ", "")}%"));
        }

        if (req.IsMississaugaResident != null) {
            Expression<Func<MemberModel, bool>> expr = m => 
                m.Membership != null
                && m.Membership.Address != null
                && EF.Functions.ILike(m.Membership.Address.City, "Mississauga");

            query = query.Where((bool) req.IsMississaugaResident
                ? expr
                : Expression.Lambda<Func<MemberModel, bool>>(Expression.Not(expr.Body), expr.Parameters)
            );
        }

        if (req.JoinedFrom != null) {
            query = query.Where(m => m.JoinedDate >= DateOnly.FromDateTime((DateTime) req.JoinedFrom));
        }

        if (req.JoinedTo != null) {
            query = query.Where(m => m.JoinedDate <= DateOnly.FromDateTime((DateTime) req.JoinedTo));
        }

        if (req.SortFirstName != null) {
            query = query.Sort(m => m.FirstName, (SortOrder) req.SortFirstName);
        }

        query = query.Sort(m => m.FirstName, req.SortFirstName);
        query = query.Sort(m => m.LastName, req.SortLastName);
        query = query.Sort(m => m.JoinedDate, req.SortJoinedDate);

        return query;
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

    public async Task<GetMembersCountsResponse?> GetMembersCounts() {
        var query = _context.Members
            .AsNoTracking()
            .AsQueryable()
            .Include(m => m.Membership)
                .ThenInclude(m => m != null ? m.Address : null)
            .Where(m => m.Membership!.IsActive)
            .GroupBy(m => true)
            .Select(g => new GetMembersCountsResponse {
                TotalCount = g.Count(),
                MississaugaCount = g.Count(m => m.Membership != null
                    && m.Membership.Address != null
                    && m.Membership.Address.City.ToLower() == "mississauga"),
            });

        return await query.SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<MemberModel>> GetMembersByDate(GetMembersByDateRequest req) {
        var query = _context.Members
            .AsNoTracking()
            .AsQueryable();

        query = query.Include(m => m.Membership);

        query = query.Where(m => m.Membership!.IsActive);

        query = query.Where(m => m.JoinedDate >= DateOnly.FromDateTime(req.JoinedFrom));

        query = query.Where(m => m.JoinedDate <= DateOnly.FromDateTime(req.JoinedTo));

        return await query.ToListAsync();
    }
}