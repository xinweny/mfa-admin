using System.ComponentModel.DataAnnotations;

namespace Mfa.Dtos;

public class UpdateUserDto {
    public string? FirstName { get; init; }
    
    public string? LastName { get; init; }

    public string? Email { get; init; }

    public int? PhoneNumber { get; init; }

    public string? Title { get; init; }
    public int? MembershipId { get; init; }
}