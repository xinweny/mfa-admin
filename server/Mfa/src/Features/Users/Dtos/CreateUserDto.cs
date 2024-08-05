namespace Mfa.Dtos;

public record CreateUserDto {
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public int? PhoneNumber { get; init; }

    public string? Title { get; init; }
    
    public required int MembershipId { get; init; }
}