namespace Mfa.Modules.Member;

public class CreateMemberRequest {
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required int MembershipId { get; set; }
    public DateOnly? JoinedDate { get; set; }
}