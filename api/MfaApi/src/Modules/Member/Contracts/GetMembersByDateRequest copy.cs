namespace MfaApi.Modules.Member;

public class GetMembersByDateRequest {
    public DateTime? JoinedFrom { get; set; }
    public DateTime? JoinedTo { get; set; }
}