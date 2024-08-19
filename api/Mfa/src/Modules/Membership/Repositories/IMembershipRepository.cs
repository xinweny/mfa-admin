using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipRepository {
    Task<IEnumerable<Membership>> GetMemberships();
    Task<Membership?> GetMembershipById(int id);
    Task CreateMembership(Membership membership);
    Task UpdateMembership(Membership membership, UpdateMembershipRequest req);
    Task UpdateMembershipAddressId(Membership membership, int? addressId);
    Task DeleteMembership(Membership membership);
}