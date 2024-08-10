using Microsoft.EntityFrameworkCore;

using Mfa.Data;
using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;

namespace Mfa.Repositories;

public class MemberRepository: IMemberRepository {
    private readonly MfaDbContext _context;

    public MemberRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task<Member> GetMemberById(int id) {
        Member member = await _context.Members.FindAsync(id)
            ?? throw new KeyNotFoundException();

        return member;
    }

    public async Task<IEnumerable<GetMembersResponseDto>> GetMembers(GetMembersRequestDto dto) {
        var membersQuery = from member in _context.Members
            select member;

        string? query = dto.Query;
        
        if (!string.IsNullOrEmpty(query)) {
            string formattedQuery = query.ToUpper();

            membersQuery = membersQuery
                .Where(member => $"{member.FirstName} {member.LastName}".Contains(formattedQuery, StringComparison.CurrentCultureIgnoreCase));
        }

        var members = await membersQuery
            .Include(member => member.ToGetMembersResponseDto())
            .ToListAsync();

        return members;
    }

    public async Task<Member> CreateMember(Member member) {
        _context.Add(member);

        await _context.SaveChangesAsync();

        return member;
    }

    public async Task<Member> UpdateMember(Member member, UpdateMemberRequestDto dto) {
        member.UpdatedAt = DateTime.UtcNow;

        _context.Entry(member).CurrentValues.SetValues(dto);
        
        await _context.SaveChangesAsync();

        return member;
    }

    public async Task DeleteMember(Member member) {
        _context.Members.Remove(member);

        await _context.SaveChangesAsync();
    }
}