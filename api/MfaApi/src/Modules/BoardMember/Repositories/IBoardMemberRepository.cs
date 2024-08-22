namespace MfaApi.Modules.BoardMember;

public interface IBoardMemberRepository {
    Task<BoardMemberModel> GetBoardMemberById(Guid id);
    Task<IEnumerable<BoardMemberModel>> GetBoardMembers( GetBoardMembersRequest req);
    Task<IEnumerable<BoardMemberModel>> GetMemberBoardMembers(Guid memberId);
    Task CreateBoardMember(BoardMemberModel boardMember);
    Task UpdateBoardMember(BoardMemberModel boardMember, UpdateBoardMemberRequest req);
    Task DeleteBoardMember(BoardMemberModel boardMember);
}