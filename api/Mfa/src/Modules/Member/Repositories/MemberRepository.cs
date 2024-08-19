using Microsoft.EntityFrameworkCore;

using Mfa.Data;
using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Repositories;

public class MemberRepository: IMemberRepository {
    private readonly MfaDbContext _context;

    public MemberRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task<Member?> GetMemberById(int id, GetMemberRequest? req = null) {
        Member member = await _context.Members
            .Include(m => m.Membership)
            .ThenInclude(m => m != null ? m.Address : null)
            .Where(m => m.Id == id)
            .SingleAsync()
            ?? throw new KeyNotFoundException();

        return member;
    }

    public async Task<Member?> GetMemberById(int id) {
        return await GetMemberById(id, new GetMemberRequest {
            includeAddress = false,
            includeMembership = false,
        });
    }

    public async Task<IEnumerable<Member>> GetMembers(GetMembersRequest req) {
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

    public async Task<Member> CreateMember(Member member) {
        _context.Members.Add(member);

        await _context.SaveChangesAsync();

        return member;
    }

    public async Task<IEnumerable<Member>> CreateMembers(IEnumerable<Member> members) {
        _context.Members.AddRange(members);

        await _context.SaveChangesAsync();

        return members;
    }

    public async Task<Member> UpdateMember(Member member, UpdateMemberRequest req) {
        member.UpdatedAt = DateTime.UtcNow;

        _context.Members.Entry(member).CurrentValues.SetValues(req);
        
        await _context.SaveChangesAsync();

        return member;
    }

    public async Task DeleteMember(Member member) {
        _context.Members.Remove(member);

        await _context.SaveChangesAsync();
    }
}