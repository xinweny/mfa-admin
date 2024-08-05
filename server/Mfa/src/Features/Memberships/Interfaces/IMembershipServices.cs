using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipServices {
    Task<IEnumerable<Membership>> GetMembershipsAsync();
    Task<Membership> GetMembershipByIdAsync(int id);
    Task CreateMembershipAsync(CreateMembershipDto data);
    Task UpdateMembershipAsync(int id, UpdateMembershipDto data);
    Task DeleteMembershipAsync(int id);
}