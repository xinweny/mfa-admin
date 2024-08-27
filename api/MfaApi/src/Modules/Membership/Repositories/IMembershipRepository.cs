namespace MfaApi.Modules.Membership;

public interface IMembershipRepository {
    Task<IEnumerable<MembershipModel>> GetMemberships(GetMembershipsRequest req);
    Task<MembershipModel> GetMembershipById(Guid id);
    Task CreateMembership(MembershipModel membership);
    Task UpdateMembership(MembershipModel membership, UpdateMembershipRequest req);
    Task DeleteMembership(MembershipModel membership);
}