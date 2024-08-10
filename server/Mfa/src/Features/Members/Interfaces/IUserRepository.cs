using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMemberRepository {
    Task<IEnumerable<GetMembersResponseDto>> GetMembers(GetMembersRequestDto dto);
    Task<Member> GetMemberById(int id);
    Task<Member> CreateMember(Member user);
    Task<Member> UpdateMember(Member user, UpdateMemberRequestDto dto);
    Task DeleteMember(Member user);
}