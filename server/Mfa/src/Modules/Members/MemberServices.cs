using Mfa.Mappers;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Services;

public class MemberServices : IMemberServices
{
    private readonly IMemberRepository _userRepository;

    public MemberServices(IMemberRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<int> CreateMember(CreateMemberRequest dto)
    {
        Member user = await _userRepository.CreateMember(dto.ToMember());

        return user.Id;
    }

    public async Task DeleteMember(int id)
    {
        Member user = await _userRepository.GetMemberById(id);

        await _userRepository.DeleteMember(user);
    }

    public async Task<GetMemberResponse> GetMemberById(int id)
    {
        Member user = await _userRepository.GetMemberById(id);

        return user.ToGetMemberResponse();
    }

    public async Task<IEnumerable<GetMembersResponse>> GetMembers(GetMembersRequest dto)
    {
        return await _userRepository.GetMembers(dto);;
    }

    public async Task UpdateMember(int id, UpdateMemberRequest dto)
    {
        Member user = await _userRepository.GetMemberById(id);

        await _userRepository.UpdateMember(user, dto);
    }
}