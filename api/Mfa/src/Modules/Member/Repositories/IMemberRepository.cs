using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMemberRepository {
    Task<IEnumerable<Member>> GetMembers(GetMembersRequest req);
    Task<Member?> GetMemberById(int id);
    Task<Member?> GetMemberById(int id, GetMemberRequest req);
    Task CreateMember(Member member);
    Task CreateMembers(IEnumerable<Member> members);
    Task UpdateMember(Member member, UpdateMemberRequest req);
    Task DeleteMember(Member member);
}