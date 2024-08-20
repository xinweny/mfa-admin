using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Mfa.Database;

namespace Mfa.Modules.Member;

public class MemberRepository: IMemberRepository {
    private readonly MfaDbContext _context;
    private readonly IValidator<MemberModel> _validator;

    public MemberRepository(MfaDbContext context, IValidator<MemberModel> validator) {
        _context = context;
        _validator = validator;
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

        return await query.SingleAsync() ?? throw new KeyNotFoundException();
    }

    public async Task<MemberModel?> GetMemberById(int id) {
        return await GetMemberById(id, false);
    }

    public async Task<IEnumerable<MemberModel>> GetMembers(GetMembersRequest req) {
        var membersQuery = from member in _context.Members
            select member;

        string? query = req.Query;
        
        if (!string.IsNullOrEmpty(query)) {
            string formattedQuery = query.ToUpper();

            membersQuery = membersQuery
                .Where(m => $"{m.FirstName} {m.LastName}".Contains(formattedQuery, StringComparison.CurrentCultureIgnoreCase));
        }

        var members = await membersQuery
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null)
            .ToListAsync();

        return members;
    }

    public async Task CreateMember(MemberModel member) {
        _validator.ValidateAndThrow(member);

        _context.Members.Add(member);

        await _context.SaveChangesAsync();
    }

    public async Task CreateMembers(IEnumerable<MemberModel> members) {
        foreach (MemberModel member in members) {
            _validator.ValidateAndThrow(member);
        }

        _context.Members.AddRange(members);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateMember(MemberModel member, UpdateMemberRequest req) {
        member.UpdatedAt = DateTime.UtcNow;

        _context.Members.Entry(member).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(member);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMember(MemberModel member) {
        _context.Members.Remove(member);

        await _context.SaveChangesAsync();
    }
}