namespace MfaApi.Modules.BoardMember;

public class UpdateBoardMemberRequest {
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public BoardPosition? BoardPosition { get; set; }
}