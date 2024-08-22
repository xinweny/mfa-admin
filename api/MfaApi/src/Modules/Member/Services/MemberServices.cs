using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Member;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(
        IMemberRepository memberRepository
    ) {
        _memberRepository = memberRepository;
    }

    public async Task<GetMemberResponse> GetMemberById(int id) {
        var member = await _memberRepository.GetMemberById(id);

        return member.ToGetMemberResponse();
    }

    public async Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest req) {
        var members = await _memberRepository.GetMembers(req);

        return members.Select(m => m.ToGetMembersResponse());
    }

    public async Task UpdateMember(int id, UpdateMemberRequest req) {
        var member = await _memberRepository.GetMemberById(id);

        await _memberRepository.UpdateMember(member, req);
    }

    public async Task CreateMember(CreateMemberRequest req) {
        await _memberRepository.CreateMember(req.ToMember());
    }

    public async Task DeleteMember(int id) {
        var member = await _memberRepository.GetMemberById(id);

        await _memberRepository.DeleteMember(member);
    }
}