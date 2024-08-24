namespace MfaApi.Modules.Membership;

public class UpdateMembershipRequest {
    public MembershipType? MembershipType { get; set; }
    public DateOnly? StartDate { get; set; }
}