using Mfa.Common.Enums;

namespace Mfa.Modules.BoardMember;

public class GetBoardMembersRequest {
    public IEnumerable<BoardPosition>? BoardPositions { get; set; }  = [];
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

    public SortOrder? SortDate { get; set; }
    public SortOrder? SortTimeServed { get; set; }
}