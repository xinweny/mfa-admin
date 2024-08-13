using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Enums;

namespace Mfa.Models;

public class Membership {
    [Key]
    public int Id { get; set; }

    [Required]
    public required MembershipTypes MembershipType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(Address))]
    public int? AddressId { get; set; }
    public Address? Address;

    public ICollection<Member>? Members { get; }
    public ICollection<MembershipPayment>? Payments { get; }

    public Membership() {
        CreatedAt = DateTime.Now;
    }
}