using Microsoft.EntityFrameworkCore;

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

    public async Task DeleteMembership(Membership membership)
    {
        _context.Memberships.Remove(membership);

        await _context.SaveChangesAsync();
    }

    public async Task<Membership?> GetMembershipById(int id) {
        Membership membership = await _context.Memberships
            .Where(m => m.Id == id)
            .Include(m => m.Address)
            .Include(m => m.Members)
            .SingleAsync()
            ?? throw new KeyNotFoundException();

        return membership;
    }
    
    public async Task<IEnumerable<Membership>> GetMemberships()
    {
        var memberships = await _context.Memberships
            .Include(m => m.Address)
            .Include(m => m.Members)
            .ToListAsync();
        
        return memberships;
    }

    public async Task<Membership> UpdateMembership(Membership membership, UpdateMembershipRequest req)
    {
        membership.UpdatedAt = DateTime.UtcNow;

        _context.Memberships.Entry(membership).CurrentValues.SetValues(req);
        
        await _context.SaveChangesAsync();

        return membership;
    }
}