using Mfa.Data;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task DeleteMembership(Membership membership)
    {
        _context.Memberships.Remove(membership);

        await _context.SaveChangesAsync();
    }

    public async Task<Membership> GetMembershipById(int id)
    {
        Membership membership = await _context.Memberships
            .Where(m => m.Id == id)
            .Include(m => m.Address)
            .FirstAsync()
            ?? throw new KeyNotFoundException();

        return membership;
    }

    public Task<IEnumerable<GetMembershipsResponse>> GetMemberships(GetMembershipsRequest dto)
    {
        throw new NotImplementedException();
    }

    public async Task<Membership> UpdateMembership(Membership membership, UpdateMembershipRequest dto)
    {
        membership.UpdatedAt = DateTime.UtcNow;

        _context.Memberships.Entry(membership).CurrentValues.SetValues(dto);

        if (membership.Address != null && dto.Address != null) {
            _context.Addresses.Entry(membership.Address).CurrentValues.SetValues(dto.Address);
        }
        
        await _context.SaveChangesAsync();

        return membership;
    }
}