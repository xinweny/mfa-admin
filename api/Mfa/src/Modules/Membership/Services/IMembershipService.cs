using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipService {
    Task<IEnumerable<GetMembershipsResponse>> GetMemberships();
    Task<GetMembershipResponse> GetMembershipById(int id);
    Task CreateMembership(CreateMembershipRequest req);
    Task UpdateMembership(int id, UpdateMembershipRequest req);
    Task DeleteMembership(int id);
}