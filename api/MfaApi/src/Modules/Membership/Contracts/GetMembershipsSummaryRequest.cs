namespace MfaApi.Modules.Membership;

public class GetMembershipsSummaryRequest {
    public int DueYear { get; set; } = DateTime.UtcNow.Year;
}