using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Features.Users;

namespace Mfa.Features.Hosts;

public class Host {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }

    [Required]
    public required int UserId { get; set; }

    [Required]
    [ForeignKey(nameof(UserId))]
    public required User User;
}