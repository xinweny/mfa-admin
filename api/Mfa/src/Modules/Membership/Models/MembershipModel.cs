using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Modules.Address;
using Mfa.Modules.Member;
using Mfa.Modules.Due;

namespace Mfa.Modules.Membership;

[Table("memberships")]
public class MembershipModel {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("membership_type"), Required]
    public required MembershipType MembershipType { get; set; }
    [Column("created_at"), Required]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("address_id"), ForeignKey(nameof(Address))]
    public int? AddressId { get; set; }
    public AddressModel? Address;

    public ICollection<MemberModel> Members { get; set; } = [];
    public ICollection<DueModel> Dues { get; set; } = [];

    public MembershipModel() {
        CreatedAt = DateTime.UtcNow;
    }
}