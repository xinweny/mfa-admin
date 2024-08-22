namespace MfaApi.Modules.BoardMember;

public interface IBoardMemberRepository {
    Task<BoardMemberModel> GetBoardMemberById(int id);
    Task<IEnumerable<BoardMemberModel>> GetBoardMembers( GetBoardMembersRequest req);
    Task<IEnumerable<BoardMemberModel>> GetMemberBoardMembers(int memberId);
    Task CreateBoardMember(BoardMemberModel boardMember);
    Task UpdateBoardMember(BoardMemberModel boardMember, UpdateBoardMemberRequest req);
    Task DeleteBoardMember(BoardMemberModel boardMember);
}