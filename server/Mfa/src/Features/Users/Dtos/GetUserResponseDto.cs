namespace Mfa.Dtos;

public class GetUserResponseDto {
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Title { get; set; }
    public required int MembershipId { get; set; }
}