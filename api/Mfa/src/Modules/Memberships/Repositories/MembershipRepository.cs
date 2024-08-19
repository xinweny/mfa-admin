using Microsoft.EntityFrameworkCore;

using Mfa.Database;

namespace Mfa.Memberships;

public class MembershipRepository: IMembershipRepository
{
    private readonly MfaDbContext _context;

    public MembershipRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task CreateMembership(MembershipModel membership)
    {
        _context.Memberships.Add(membership);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteMembership(MembershipModel membership)
    {
        _context.Memberships.Remove(membership);

        await _context.SaveChangesAsync();
    }

    public async Task<MembershipModel?> GetMembershipById(int id) {
        MembershipModel membership = await _context.Memberships
            .Where(m => m.Id == id)
            .Include(m => m.Address)
            .Include(m => m.Members)
            .SingleAsync()
            ?? throw new KeyNotFoundException();

        return membership;
    }
    
    public async Task<IEnumerable<MembershipModel>> GetMemberships()
    {
        var memberships = await _context.Memberships
            .Include(m => m.Address)
            .Include(m => m.Members)
            .ToListAsync();
        
        return memberships;
    }

    public async Task UpdateMembership(MembershipModel membership, UpdateMembershipRequest req)
    {
        membership.UpdatedAt = DateTime.UtcNow;

        membership.MembershipType = req.MembershipType;
        
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMembershipAddressId(MembershipModel membership, int? addressId)
    {
        membership.UpdatedAt = DateTime.UtcNow;

        membership.AddressId = addressId;
        
        await _context.SaveChangesAsync();
    }
}