using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Infrastructure.Users;

namespace Mfa.Infrastructure.BoardPositions;

public class BoardPosition {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }
    [Required]
    public required Positions Position { get; set; }

    [Required, ForeignKey(nameof(User))]
    public required int UserId;
    [Required]
    public User? User;
}
