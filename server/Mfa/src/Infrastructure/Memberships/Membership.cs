using System.ComponentModel.DataAnnotations;

using Mfa.Infrastructure.Users;
using Mfa.Infrastructure.MembershipPayments;
using Mfa.Infrastructure.Addresses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Infrastructure.Memberships;

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