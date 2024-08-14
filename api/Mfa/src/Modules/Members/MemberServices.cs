using Mfa.Mappers;
using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Services;

public class MemberServices : IMemberServices
{
    private readonly IMemberRepository _userRepository;

    public MemberServices(IMemberRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task CreateMember(CreateMemberRequest dto)
    {
        await _userRepository.CreateMember(dto.ToMember());
    }

    public async Task DeleteMember(int id)
    {
        var member = await _userRepository.GetMemberById(id);

        await _userRepository.DeleteMember(member);
    }

    public async Task<GetMemberResponse> GetMemberById(int id)
    {
        var member = await _userRepository.GetMemberById(id);

        return member.ToGetMemberResponse();
    }

    public async Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto)
    {
        return await _userRepository.GetMembers(dto);;
    }

    public async Task UpdateMember(int id, UpdateMemberRequest dto)
    {
        var member = await _userRepository.GetMemberById(id);

        await _userRepository.UpdateMember(member, dto);
    }
}