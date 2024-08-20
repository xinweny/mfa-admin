
namespace Mfa.Modules.BoardMember;

public class BoardMemberService: IBoardMemberService {
    private readonly IBoardMemberRepository _boardMemberRepository;

    public BoardMemberService(IBoardMemberRepository boardMemberRepository) {
        _boardMemberRepository = boardMemberRepository;
    }

    public async Task CreateBoardMember(CreateBoardMemberRequest req)
    {
        await _boardMemberRepository.CreateBoardMember(req);
    }

    public Task DeleteBoardMember(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetBoardMembersResponse>> GetBoardMembers(GetBoardMembersRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetMemberBoardMembersResponse>> GetMemberBoardMembers(int memberId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBoardMember(int id, UpdateBoardMemberRequest req)
    {
        throw new NotImplementedException();
    }
}