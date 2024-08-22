using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MfaApi.Modules.Membership;
using MfaApi.Modules.BoardMember;
using MfaApi.Modules.Exchange;

namespace MfaApi.Modules.Member;

[Table("members")]
public class MemberModel {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("first_name"), Required]
    public required string FirstName { get; set; }
    [Column("last_name"), Required]
    public required string LastName { get; set; }
    [Column("email"), Required]
    public required string Email { get; set; }
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
    [Column("joined_date")]
    public DateOnly? JoinedDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("membership_id"), Required, ForeignKey(nameof(Membership))]
    public required Guid MembershipId { get; set; }
    public MembershipModel? Membership;

    public ICollection<BoardMemberModel> BoardPositions = [];
    public ICollection<ExchangeModel> Exchanges = [];

    public MemberModel() {
        CreatedAt = DateTime.UtcNow;
    }
}