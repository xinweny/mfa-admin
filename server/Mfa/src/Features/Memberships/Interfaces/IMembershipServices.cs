using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipServices {
    Task<IEnumerable<Membership>> GetMemberships();
    Task<Membership> GetMembershipById(int id);
    Task CreateMembership(CreateMembershipRequestDto dto);
    Task UpdateMembership(int id, UpdateMembershipRequestDto dto);
    Task DeleteMembership(int id);
}