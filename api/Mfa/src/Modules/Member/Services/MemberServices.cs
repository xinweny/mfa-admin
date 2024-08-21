using Mfa.Modules.Membership;

namespace Mfa.Modules.Member;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMembershipRepository _membershipRepository;

    public MemberService(
        IMemberRepository memberRepository,
        IMembershipRepository membershipRepository
    ) {
        _memberRepository = memberRepository;
        _membershipRepository = membershipRepository;
    }

    public async Task<GetMemberResponse> GetMemberById(int id) {
        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException("Member not found.");

        return member.ToGetMemberResponse();
    }

    public async Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest req) {
        var members = await _memberRepository.GetMembers(req);

        return members.Select(m => m.ToGetMembersResponse());
    }

    public async Task UpdateMember(int id, UpdateMemberRequest req) {
        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException("Member not found.");

        await _memberRepository.UpdateMember(member, req);
    }

    public async Task CreateMember(CreateMemberRequest req) {
        var membership = await _membershipRepository.GetMembershipById(req.MembershipId)
            ?? throw new KeyNotFoundException("Membership not found.");

        await _memberRepository.CreateMember(req.ToMember(), membership);
    }

    public async Task DeleteMember(int id) {
        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException("Member not found.");

        var membership = member.Membership
            ?? throw new KeyNotFoundException("Membership not found.");

        await _memberRepository.DeleteMember(member, membership);
    }
}