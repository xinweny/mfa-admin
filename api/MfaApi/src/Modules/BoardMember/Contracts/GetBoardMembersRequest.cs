using MfaApi.Core.Sort;

namespace MfaApi.Modules.BoardMember;

public class GetBoardMembersRequest {
    public List<BoardPosition>? BoardPositions { get; set; }  = [];
    public DateOnly? DateFrom { get; set; }
    public DateOnly? DateTo { get; set; }

    public SortOrder? SortDate { get; set; }
    public SortOrder? SortTimeServed { get; set; }
}