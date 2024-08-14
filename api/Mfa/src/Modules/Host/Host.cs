using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Models;

public class Host {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }

    [Required, ForeignKey(nameof(Member))]
    public required int MemberId { get; set; }
    [Required]
    public Member? Member;
}