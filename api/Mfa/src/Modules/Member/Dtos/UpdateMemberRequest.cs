namespace Mfa.Dtos;

public class UpdateMemberRequest {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Title { get; set; }
    public int? MembershipId { get; set; }
}