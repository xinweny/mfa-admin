using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Modules.Membership;

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

    public async Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req) {
        var membersQuery = from member in _context.Members
            select member;

        string? query = req.Query;
        
        if (!string.IsNullOrEmpty(query)) {
            var fullNameFilter = MemberUtils.GetFullNameFilter(query);

            membersQuery = membersQuery
                .Where(fullNameFilter);
        }

        var members = await membersQuery
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null)
            .ToListAsync();

        return members;
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