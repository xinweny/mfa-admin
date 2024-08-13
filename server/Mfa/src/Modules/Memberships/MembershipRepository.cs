using Mfa.Data;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly MfaDbContext _context;

    public MembershipRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task<Membership> CreateMembership(Membership membership)
    {
        _context.Memberships.Add(membership);

        await _context.SaveChangesAsync();

        return membership;
    }

    public Task DeleteMembership(Membership membership)
    {
        throw new NotImplementedException();
    }

    public async Task<Membership> GetMembershipById(int id)
    {
        Membership membership = await _context.Memberships
            .FindAsync(id)    
            ?? throw new KeyNotFoundException();

        return membership;
    }

    public Task<IEnumerable<GetMembershipsResponse>> GetMemberships(GetMembershipsRequest dto)
    {
        throw new NotImplementedException();
    }

    public Task<Membership> UpdateMembership(Membership membership, UpdateMembershipRequest dto)
    {
        throw new NotImplementedException();
    }
}