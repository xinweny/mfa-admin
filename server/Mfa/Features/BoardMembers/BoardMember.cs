using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Features.Users;

namespace Mfa.Features.BoardMembers;

public class BoardMember {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }

    [Required]
    public required BoardPositions Position { get; set; }

    [Required]
    public required int UserId;

    [Required]
    [ForeignKey(nameof(UserId))]
    public required User User;
}

public enum BoardPositions {
    President,
    VicePresident,
    Secretary,
    Treasurer,
    BoardMember
}