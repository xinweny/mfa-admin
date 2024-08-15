using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Models;

[Table("users")]
public class User {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("email"), Required]
    public required string Email { get; set; }
    [Column("user_name"), Required]
    public required string UserName { get; set; }

    [Column("member_id"), Required, ForeignKey(nameof(Member))]
    public required int MemberId { get; set; }
    public Member? Member;
}