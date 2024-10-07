namespace MfaApi.Modules.Member;

public class MemberSummaryService : IMemberSummaryService
{
    private readonly IMemberRepository _memberRepository;

    public MemberSummaryService(
        IMemberRepository memberRepository
    ) {
        _memberRepository = memberRepository;
    }

    public async Task<GetMembersCountsResponse?> GetMembersCounts() {
        return await _memberRepository.GetMembersCounts();
    }
}