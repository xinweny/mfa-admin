using Microsoft.EntityFrameworkCore;

using Mfa.Data;
using Mfa.Models;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Mappers;

namespace Mfa.Services;
public class MembershipServices: IMembershipServices {
    private readonly MfaDbContext _context;

    public MembershipServices(MfaDbContext context) {
        _context = context;
    }

    public Task CreateMembership(CreateMembershipRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMembership(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Membership> GetMembershipById(int id)
    {
        Membership membership = await _context.Memberships
            .Include(m =>
                m.Members
                    .Select(member => member.ToMembershipMembersDto())
            )
            .Include(m => m.Address)
            .FirstOrDefaultAsync(m => m.Id == id)    
            ?? throw new KeyNotFoundException();

        return membership;
    }

    public Task<IEnumerable<Membership>> GetMemberships()
    {
        throw new NotImplementedException();
    }

    public Task UpdateMembership(int id, UpdateMembershipRequestDto dto)
    {
        throw new NotImplementedException();
    }
}