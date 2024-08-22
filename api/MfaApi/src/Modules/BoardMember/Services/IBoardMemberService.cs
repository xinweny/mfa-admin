namespace MfaApi.Modules.BoardMember;

public interface IBoardMemberService {
    Task<IEnumerable<GetBoardMembersResponse>> GetBoardMembers(GetBoardMembersRequest req);
    Task<IEnumerable<GetMemberBoardMembersResponse>> GetMemberBoardMembers(int memberId);
    Task CreateBoardMember(CreateBoardMemberRequest req);
    Task UpdateBoardMember(int id, UpdateBoardMemberRequest req);
    Task DeleteBoardMember(int id);
}