using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipRepository {
    Task<IEnumerable<Membership>> GetMemberships(GetMembershipsRequest req);
    Task<Membership?> GetMembershipById(int id);
    Task<Membership> CreateMembership(Membership membership);
    Task<Membership> UpdateMembership(Membership membership, UpdateMembershipRequest req);
    Task DeleteMembership(Membership membership);
}