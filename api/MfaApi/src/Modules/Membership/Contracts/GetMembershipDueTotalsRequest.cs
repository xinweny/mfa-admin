namespace MfaApi.Modules.Membership;

public class GetMembershipDueTotalsRequest {
    public int DueYear { get; set; } = DateTime.UtcNow.Year;
}