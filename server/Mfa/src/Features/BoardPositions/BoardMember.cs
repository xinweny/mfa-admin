using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Enums;

namespace Mfa.Models;

public class BoardPosition {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }
    [Required]
    public required BoardPositionTitles Position { get; set; }

    [Required, ForeignKey(nameof(Member))]
    public required int MemberId;
    [Required]
    public Member? Member;
}
