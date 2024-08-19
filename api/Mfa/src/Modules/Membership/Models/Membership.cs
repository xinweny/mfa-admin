using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Enums;

namespace Mfa.Models;

[Table("memberships")]
public class Membership {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("membership_type"), Required]
    public required MembershipTypes MembershipType { get; set; }
    [Column("created_at"), Required]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("address_id"), ForeignKey(nameof(Address))]
    public int? AddressId { get; set; }
    public Address? Address;

    public virtual ICollection<Member>? Members { get; set; }
    public virtual ICollection<MembershipPayment>? Payments { get; set; }

    public Membership() {
        CreatedAt = DateTime.UtcNow;
    }
}