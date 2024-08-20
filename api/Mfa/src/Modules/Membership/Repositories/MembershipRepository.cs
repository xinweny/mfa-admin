using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Mfa.Database;

namespace Mfa.Modules.Membership;

public class MembershipRepository: IMembershipRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<MembershipModel> _validator;

    public MembershipRepository(MfaDbContext context, IValidator<MembershipModel>  validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateMembership(MembershipModel membership)
    {
        _validator.ValidateAndThrow(membership);

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

        _context.Memberships.Entry(membership).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(membership);
        
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMembershipAddressId(MembershipModel membership, int? addressId)
    {
        membership.UpdatedAt = DateTime.UtcNow;

        membership.AddressId = addressId;
        
        await _context.SaveChangesAsync();
    }
}