namespace Mfa.Dtos;

public class CreateMembershipMember {
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Title { get; set; }
}