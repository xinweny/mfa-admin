namespace MfaApi.Modules.BoardMember;

public class GetMemberBoardMembersResponse {
    public required int Id { get; set; }
    public required DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public required BoardPosition BoardPosition { get; set; }
    public required int MemberId { get; set; }
}