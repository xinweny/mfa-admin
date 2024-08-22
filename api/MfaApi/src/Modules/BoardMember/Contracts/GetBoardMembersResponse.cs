namespace MfaApi.Modules.BoardMember;

public class GetBoardMembersResponse {
    public required Guid Id { get; set; }
    public required DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public required BoardPosition BoardPosition { get; set; }
    public required Guid MemberId { get; set; }
    public MemberDto? Member { get; set; }

    public class MemberDto {
        public required Guid Id;
        public required string FirstName;
        public required string LastName;
    }
}