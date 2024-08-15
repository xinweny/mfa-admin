using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Models;

[Table("delegates")]
public class Delegate {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("year"), Required]
    public required int Year { get; set; }

    [Column("member_id"), Required, ForeignKey(nameof(Member))]
    public required int MemberId { get; set; }
    [Required]
    public Member? Member;
}