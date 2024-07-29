using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Features.Users;
using Mfa.Features.MembershipPayments;

namespace Mfa.Features.Memberships;

public class Membership {
    [Key]
    public int Id { get; set; }

    [Required]
    public required MembershipTypes Type { get; set; }

    public DateTime CreatedAt { get; set; }

    [InverseProperty("Membership")]
    public ICollection<User> Users { get; } = [];

    [InverseProperty("Membership")]
    public ICollection<MembershipPayment> Payments { get; } = [];
}
public enum MembershipTypes {
    Single,
    Family,
    Honorary
}