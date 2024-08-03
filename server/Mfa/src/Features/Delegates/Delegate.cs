using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mfa.Models;

public class Delegate {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }

    [Required, ForeignKey(nameof(User))]
    public required int UserId { get; set; }
    [Required]
    public required User? User;
}