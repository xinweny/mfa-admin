namespace MfaApi.Modules.Membership;

public class UpdateMembershipRequest {
    public MembershipType MembershipType { get; set; }
    public DateTime StartDate { get; set; }
}