namespace MfaApi.Modules.Membership;

public interface IMembershipService {
    Task<IEnumerable<GetMembershipsResponse>> GetMemberships();
    Task<GetMembershipResponse> GetMembershipById(Guid id);
    Task CreateMembership(CreateMembershipRequest req);
    Task UpdateMembership(Guid id, UpdateMembershipRequest req);
    Task DeleteMembership(Guid id);
}