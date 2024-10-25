using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MfaApi.Modules.Address;
using MfaApi.Modules.Member;
using MfaApi.Modules.Due;

namespace MfaApi.Modules.Membership;

[Table("memberships")]
public class MembershipModel {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("membership_type"), Required]
    public required MembershipType MembershipType { get; set; }
    [Column("start_date"), Required]
    public required DateOnly StartDate { get; set; }
    [Column("created_at"), Required]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [Column("is_archived"), Required]
    public required bool IsArchived { get; set; }

    [Column("address_id"), ForeignKey(nameof(Address))]
    public Guid? AddressId { get; set; }
    public AddressModel? Address;

    public virtual ICollection<MemberModel> Members { get; set; } = [];
    public virtual ICollection<DueModel> Dues { get; set; } = [];

    public MembershipModel() {
        CreatedAt = DateTime.UtcNow;
    }
}