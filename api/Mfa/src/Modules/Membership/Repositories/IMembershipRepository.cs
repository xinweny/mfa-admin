namespace Mfa.Modules.Membership;

public interface IMembershipRepository {
    Task<IEnumerable<MembershipModel>> GetMemberships();
    Task<MembershipModel> GetMembershipById(int id);
    Task CreateMembership(MembershipModel membership);
    Task UpdateMembership(MembershipModel membership, UpdateMembershipRequest req);
    Task DeleteMembership(MembershipModel membership);
}