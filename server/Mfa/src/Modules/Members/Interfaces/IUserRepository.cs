using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMemberRepository {
    Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto);
    Task<Member> GetMemberById(int id);
    Task<Member> CreateMember(Member user);
    Task<Member> UpdateMember(Member user, UpdateMemberRequest dto);
    Task DeleteMember(Member user);
}