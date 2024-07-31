using System.ComponentModel.DataAnnotations;

using Mfa.Infrastructure.Users;
using Mfa.Infrastructure.MembershipPayments;
using Mfa.Infrastructure.Addresses;

namespace Mfa.Infrastructure.Memberships;

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