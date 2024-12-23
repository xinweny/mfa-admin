using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MfaApi.Modules.Member;

namespace MfaApi.Modules.BoardMember;

[Table("board_members")]
public class BoardMemberModel {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("start_date"), Required]
    public required DateOnly StartDate { get; set; }
    [Column("end_date")]
    public DateOnly? EndDate { get; set; }
    [Column("board_position"), Required]
    public required BoardPosition BoardPosition { get; set; }

    [Column("member_id"), Required, ForeignKey(nameof(Member))]
    public required Guid MemberId;
    [Required]
    public virtual MemberModel? Member { get; set; }
}
