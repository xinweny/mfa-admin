using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Enums;

namespace Mfa.Models;

[Table("board_members")]
public class BoardMember {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("start_date"), Required]
    public required DateTime StartDate { get; set; }
    [Column("end_date")]
    public DateTime? EndDate { get; set; }
    [Column("board_position"), Required]
    public required BoardPositions BoardPosition { get; set; }

    [Column("member_id"), Required, ForeignKey(nameof(Member))]
    public required int MemberId;
    [Required]
    public Member? Member;
}
