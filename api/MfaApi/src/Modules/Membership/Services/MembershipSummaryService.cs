namespace MfaApi.Modules.Membership;

public class MembershipSummaryService: IMembershipSummaryService {
    private readonly IMembershipRepository _membershipRepository;

    public MembershipSummaryService(IMembershipRepository membershipRepository) {
        _membershipRepository = membershipRepository;
    }

    public async Task<GetMembershipDueTotalsResponse?> GetMembershipDueTotals(GetMembershipDueTotalsRequest req)
    {
        return await _membershipRepository.GetMembershipDueTotals(req);
    }

    public async Task<GetMembershipTypeCountsResponse?> GetMembershipTypeCounts() {
        return await _membershipRepository.GetMembershipTypeCounts();
    }
}