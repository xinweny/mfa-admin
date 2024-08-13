using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipServices {
    Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships();
    Task<GetMembershipResponseDto> GetMembershipById(int id);
    Task CreateMembership(CreateMembershipRequestDto dto);
    Task UpdateMembership(int id, UpdateMembershipRequestDto dto);
    Task DeleteMembership(int id);
}