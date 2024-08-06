using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipRepository {
    Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships(GetMembershipsRequestDto dto);
    Task<User> GetMembershipById(int id);
    Task<User> CreateMembership(Membership membership);
    Task<User> UpdateMembership(User user, UpdateUserRequestDto dto);
    Task DeleteUser(User user);
}