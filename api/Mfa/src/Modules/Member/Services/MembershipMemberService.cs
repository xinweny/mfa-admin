using Mfa.Modules.Membership;

namespace Mfa.Modules.Member;

public class MembershipMemberService: IMembershipMemberService {
    private readonly IMemberRepository _memberRepository;
    private readonly IMembershipRepository _membershipRepository;

    public MembershipMemberService(
        IMemberRepository memberRepository,
        IMembershipRepository membershipRepository
    ) {
        _memberRepository = memberRepository;
        _membershipRepository = membershipRepository;
    }

    public async Task CreateMember(CreateMemberRequest req, int membershipId)
    {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException("Membership not found.");

        await _memberRepository.CreateMember(req.ToMember(membershipId), membership);
    }

    public async Task DeleteMember(int id, int membershipId)
    {
        var membership = await _membershipRepository.GetMembershipById(membershipId)
            ?? throw new KeyNotFoundException("Membership not found.");

        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException("Member not found.");

        await _memberRepository.DeleteMember(member, membership);
    }
}