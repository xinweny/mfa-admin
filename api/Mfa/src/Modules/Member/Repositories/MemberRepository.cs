using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Mfa.Database;
using Mfa.Modules.Membership;

namespace Mfa.Modules.Member;

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

    public async Task<MemberModel?> GetMemberById(int id, bool includeMembership) {
        var query = _context.Members.AsQueryable();

        if (includeMembership) {
            query
                .Include(m => m.Membership)
                .ThenInclude(m => m != null ? m.Address : null)
                .Include(m => m.Membership)
                .ThenInclude(m => m != null ? m.Members : null);
        }
            
        query.Where(m => m.Id == id);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<MemberModel?> GetMemberById(int id) {
        return await GetMemberById(id, false);
    }

    public async Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req) {
        var membersQuery = from member in _context.Members
            select member;

        string? query = req.Query;
        
        if (!string.IsNullOrEmpty(query)) {
            membersQuery = membersQuery
                .Where(m => m.DoesFullNameContainQuery(query));
        }

        var members = await membersQuery
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null)
            .ToListAsync();

        return members;
    }

    public async Task CreateMember(MemberModel member, MembershipModel membership) {
        membership.Members!.Add(member);

        _membershipValidator.ValidateAndThrow(membership);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateMember(MemberModel member, UpdateMemberRequest req) {
        member.UpdatedAt = DateTime.UtcNow;

        _context.Members.Entry(member).CurrentValues.SetValues(req);

        _memberValidator.ValidateAndThrow(member);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMember(MemberModel member, MembershipModel membership) {
        membership.Members!.Remove(member);

        _membershipValidator.ValidateAndThrow(membership);

        await _context.SaveChangesAsync();
    }
}