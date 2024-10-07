namespace MfaApi.Modules.Member;

public interface IMemberSummaryService {
    Task<GetMembersCountsResponse?> GetMembersCounts();
}