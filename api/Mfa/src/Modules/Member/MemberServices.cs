using Mfa.Mappers;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Services;

public class MemberServices : IMemberServices
{
    private readonly IMemberRepository _memberRepository;

    public MemberServices(IMemberRepository memberRepository) {
        _memberRepository = memberRepository;
    }

    public async Task CreateMember(CreateMemberRequest dto)
    {
        await _memberRepository.CreateMember(dto.ToMember());
    }

    public async Task DeleteMember(int id)
    {
        var member = await _memberRepository.GetMemberById(id);

        await _memberRepository.DeleteMember(member);
    }

    public async Task<GetMemberResponse> GetMemberById(int id)
    {
        var member = await _memberRepository.GetMemberById(id);

        return member.ToGetMemberResponse();
    }

    public async Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto)
    {
        return await _memberRepository.GetMembers(dto);;
    }

    public async Task UpdateMember(int id, UpdateMemberRequest dto)
    {
        var member = await _memberRepository.GetMemberById(id);

        await _memberRepository.UpdateMember(member, dto);
    }
}