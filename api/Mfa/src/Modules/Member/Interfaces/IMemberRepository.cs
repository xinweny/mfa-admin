using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMemberRepository {
    Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto);
    Task<Member> GetMemberById(int id);
    Task<Member> CreateMember(Member member);
    Task<IEnumerable<Member>> CreateMembers(IEnumerable<Member> members);
    Task<Member> UpdateMember(Member member, UpdateMemberRequest dto);
    Task DeleteMember(Member member);
}