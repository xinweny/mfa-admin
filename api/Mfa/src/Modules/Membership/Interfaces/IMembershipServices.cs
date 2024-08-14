using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipServices {
    Task<IEnumerable<GetMembershipsResponse>> GetMemberships();
    Task<GetMembershipResponse> GetMembershipById(int id);
    Task CreateMembership(CreateMembershipRequest dto);
    Task UpdateMembership(int id, UpdateMembershipRequest dto);
    Task DeleteMembership(int id);
}