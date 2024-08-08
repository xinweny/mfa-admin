using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Repositories;

public class MembershipRepository : IMembershipRepository
{
    public Task<User> CreateMembership(Membership membership)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetMembershipById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetMembershipsResponseDto>> GetMemberships(GetMembershipsRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateMembership(User user, UpdateUserRequestDto dto)
    {
        throw new NotImplementedException();
    }
}