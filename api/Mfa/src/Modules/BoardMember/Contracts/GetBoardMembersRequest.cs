using Mfa.Common.Constants;

namespace Mfa.Modules.BoardMember;

public class GetBoardMembersRequest {
    public List<BoardPosition>? BoardPositions { get; set; }  = [];
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }

    public SortOrder? SortDate { get; set; }
    public SortOrder? SortTimeServed { get; set; }
}