using System.ComponentModel.DataAnnotations;

namespace Mfa.Dtos;

public class UpdateUserDto {
    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Title { get; set; }
    public int? MembershipId { get; set; }
}