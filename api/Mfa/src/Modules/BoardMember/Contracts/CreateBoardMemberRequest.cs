namespace Mfa.Modules.BoardMember;

public class CreateBoardMemberRequest {
    public required DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public required BoardPosition BoardPosition { get; set; }
    public required int MemberId { get; set; }
}