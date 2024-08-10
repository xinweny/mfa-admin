using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMemberServices {
    Task<IEnumerable<GetMembersResponseDto>> GetMembers(GetMembersRequestDto dto);
    Task<GetMemberResponseDto> GetMemberById(int id);
    Task<int> CreateMember(CreateMemberRequestDto dto);
    Task UpdateMember(int id, UpdateMemberRequestDto dto);
    Task DeleteMember(int id);
}