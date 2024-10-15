namespace MfaApi.Modules.Member;

public interface IMemberSummaryService {
    Task<GetMembersCountsResponse?> GetMembersCounts();
    Task<List<GetMembersByDateResponse>> GetMembersByDate(GetMembersByDateRequest req);
}