namespace Mfa.Modules.BoardMember;

public class UpdateBoardMemberRequest {
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public BoardPosition? BoardPosition { get; set; }
}