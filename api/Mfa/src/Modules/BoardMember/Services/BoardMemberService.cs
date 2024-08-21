namespace Mfa.Modules.BoardMember;

public class BoardMemberService: IBoardMemberService {
    private readonly IBoardMemberRepository _boardMemberRepository;

    public BoardMemberService(IBoardMemberRepository boardMemberRepository) {
        _boardMemberRepository = boardMemberRepository;
    }

    public async Task CreateBoardMember(CreateBoardMemberRequest req) {
        await _boardMemberRepository.CreateBoardMember(req.ToBoardMember());
    }

    public async Task DeleteBoardMember(int id) {
        var boardMember = await _boardMemberRepository.GetBoardMemberById(id);

        await _boardMemberRepository.DeleteBoardMember(boardMember);
    }

    public async Task<IEnumerable<GetBoardMembersResponse>> GetBoardMembers(GetBoardMembersRequest req) {
        var boardMembers = await _boardMemberRepository.GetBoardMembers(req);

        return boardMembers.Select(b => b.ToGetBoardMembersResponse());
    }

    public async Task<IEnumerable<GetMemberBoardMembersResponse>> GetMemberBoardMembers(int memberId) {
        var boardMembers = await _boardMemberRepository.GetMemberBoardMembers(memberId);

        return boardMembers.Select(b => b.ToGetMemberBoardMembersResponse());
    }

    public async Task UpdateBoardMember(int id, UpdateBoardMemberRequest req) {
        var boardMember = await _boardMemberRepository.GetBoardMemberById(id);

        await _boardMemberRepository.UpdateBoardMember(boardMember, req);
    }
}