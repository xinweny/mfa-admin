using System.ComponentModel.DataAnnotations;

using Mfa.Features.Users;
using Mfa.Features.MembershipPayments;
using Mfa.Features.Addresses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Features.Memberships;

public class Membership {
    [Key]
    public int Id { get; set; }

    [Required]
    public required MembershipTypes Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(Address))]
    public int? AddressId { get; set; }
    public Address? Address;

    public ICollection<User>? Users { get; }
    public ICollection<MembershipPayment>? Payments { get; }

    public Membership() {
        CreatedAt = DateTime.Now;
    }
}