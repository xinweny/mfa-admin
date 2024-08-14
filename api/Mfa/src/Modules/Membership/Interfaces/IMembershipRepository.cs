using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipRepository {
    Task<IEnumerable<GetMembershipsResponse>> GetMemberships(GetMembershipsRequest dto);
    Task<Membership> GetMembershipById(int id);
    Task<Membership> CreateMembership(Membership membership);
    Task<Membership> UpdateMembership(Membership membership, UpdateMembershipRequest dto);
    Task DeleteMembership(Membership membership);
}