namespace Mfa.Features.Memberships;

public class Membership {
    public int Id { get; set; }
    public required MembershipTypes Type { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Users.User> Users { get; } = [];
    public ICollection<MembershipPayments.MembershipPayment> Payments { get; } = [];
}
public enum MembershipTypes {
    Single,
    Family,
    Honorary
}