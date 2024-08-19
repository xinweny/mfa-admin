using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Addresses;
using Mfa.Members;
using Mfa.Dues;

namespace Mfa.Memberships;

[Table("memberships")]
public class MembershipModel {
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
    public AddressModel? Address;

    public virtual ICollection<MemberModel>? Members { get; set; }
    public virtual ICollection<DueModel>? Dues { get; set; }

    public MembershipModel() {
        CreatedAt = DateTime.UtcNow;
    }
}