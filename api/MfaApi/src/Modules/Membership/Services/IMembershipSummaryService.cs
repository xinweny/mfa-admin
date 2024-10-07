
namespace MfaApi.Modules.Membership;

public interface IMembershipSummaryService {
    Task<GetMembershipDueTotalsResponse?> GetMembershipDueTotals(GetMembershipDueTotalsRequest req);
    Task<GetMembershipTypeCountsResponse?> GetMembershipTypeCounts();
}