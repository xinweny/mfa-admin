namespace MfaApi.Modules.Membership;

public class GetMembershipsSummaryResponse {
    public long? TotalYearlyDuesPaid { get; set; }
    public long? TotalYearlyDuesOwed { get; set; }
}