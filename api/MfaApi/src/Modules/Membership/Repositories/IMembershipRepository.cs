namespace MfaApi.Modules.Membership;

public interface IMembershipRepository {
    IQueryable<MembershipModel> GetMembershipsQuery(GetMembershipsRequest req);
    Task<MembershipModel> GetMembershipById(Guid id);
    Task CreateMembership(MembershipModel membership);
    Task UpdateMembership(MembershipModel membership, UpdateMembershipRequest req);
    Task DeleteMembership(MembershipModel membership);

    Task<GetMembershipsSummaryResponse?> GetMembershipsSummary(GetMembershipsSummaryRequest req);
}