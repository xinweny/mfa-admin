using System.ComponentModel.DataAnnotations;

using Mfa.Features.Users;
using Mfa.Features.MembershipPayments;
using Mfa.Features.Addresses;

namespace Mfa.Features.Memberships;

public class Membership {
    [Key]
    public int Id { get; set; }

    [Required]
    public required MembershipTypes Type { get; set; }

    [Required]
    public required DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? AddressId { get; set; }

    public ICollection<User> Users { get; }

    public ICollection<MembershipPayment> Payments { get; }

    public Address? Address;

    public Membership() {
        CreatedAt = new DateTime();

        Users = [];
        Payments = [];
    }
}