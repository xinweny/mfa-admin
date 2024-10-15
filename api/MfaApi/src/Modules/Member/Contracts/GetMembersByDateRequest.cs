namespace MfaApi.Modules.Member;

public class GetMembersByDateRequest {
    public DateTime JoinedFrom { get; set; } = new DateTime(new DateTime().Year, 1, 1);
    public DateTime JoinedTo { get; set; } = new DateTime(); 
}