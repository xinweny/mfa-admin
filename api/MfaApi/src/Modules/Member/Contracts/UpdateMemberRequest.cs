namespace MfaApi.Modules.Member;

public class UpdateMemberRequest {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? JoinedDate { get; set; }
}