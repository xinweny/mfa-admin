using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Repositories;

public class MembershipRepository : IMembershipRepository
{
    public Task<Member> CreateMembership(Membership membership)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMembership(Member member)
    {
        throw new NotImplementedException();
    }

    public Task<Member> GetMembershipById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships(GetMembershipsRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Member> UpdateMembership(Member member, UpdateMemberRequestDto dto)
    {
        throw new NotImplementedException();
    }
}