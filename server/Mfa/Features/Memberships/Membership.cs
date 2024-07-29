using System.ComponentModel.DataAnnotations;

using Mfa.Features.Users;
using Mfa.Features.MembershipPayments;

namespace Mfa.Features.Memberships;

public class Membership {
    [Key]
    public int Id { get; set; }

    [Required]
    public required MembershipTypes Type { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<User> Users { get; } = [];

    public ICollection<MembershipPayment> Payments { get; } = [];
}