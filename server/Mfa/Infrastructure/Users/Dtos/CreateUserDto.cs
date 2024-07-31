using System.ComponentModel.DataAnnotations;

namespace Mfa.Infrastructure.Users;

public class CreateUserDto {
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string Email { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Title { get; set; }

    [Required]
    public required int MembershipId { get; set; }
}