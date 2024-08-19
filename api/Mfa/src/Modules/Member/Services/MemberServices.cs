using Mfa.Mappers;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository) {
        _memberRepository = memberRepository;
    }

    public async Task CreateMember(CreateMemberRequest dto)
    {
        await _memberRepository.CreateMember(dto.ToMember());
    }

    public async Task DeleteMember(int id)
    {
        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException();

        await _memberRepository.DeleteMember(member);
    }

    public async Task<GetMemberResponse> GetMemberById(int id)
    {
        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException();

        return member.ToGetMemberResponse();
    }

    public async Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto)
    {
        var members = await _memberRepository.GetMembers(dto);

        return members.Select(m => m.ToGetMembersResponse());
    }

    public async Task UpdateMember(int id, UpdateMemberRequest dto)
    {
        var member = await _memberRepository.GetMemberById(id)
            ?? throw new KeyNotFoundException();

        await _memberRepository.UpdateMember(member, dto);
    }
}