namespace MfaApi.Modules.BoardMember;

public interface IBoardMemberService {
    Task<IEnumerable<GetBoardMembersResponse>> GetBoardMembers(GetBoardMembersRequest req);
    Task<IEnumerable<GetMemberBoardMembersResponse>> GetMemberBoardMembers(Guid memberId);
    Task CreateBoardMember(CreateBoardMemberRequest req);
    Task UpdateBoardMember(Guid id, UpdateBoardMemberRequest req);
    Task DeleteBoardMember(Guid id);
}