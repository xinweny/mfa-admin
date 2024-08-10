using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipRepository {
    Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships(GetMembershipsRequestDto dto);
    Task<Membership> GetMembershipById(int id);
    Task<Membership> CreateMembership(Membership membership);
    Task<Membership> UpdateMembership(Membership membership, UpdateMembershipRequestDto dto);
    Task DeleteMembership(Membership membership);
}