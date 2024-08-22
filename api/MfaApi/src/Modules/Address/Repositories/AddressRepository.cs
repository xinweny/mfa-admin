using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Address;

public class AddressRepository : IAddressRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<AddressModel> _validator;

    public AddressRepository(MfaDbContext context, IValidator<AddressModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task<IEnumerable<AddressModel>> GetAddresses() {
        var addresses = await _context.Addresses
            .ToListAsync();
        
        return addresses;
    }

    public async Task<AddressModel> GetAddressById(int id) {
        var address = await _context.Addresses
            .FindAsync(id)
            ?? throw new KeyNotFoundException("Address not found.");

        return address;
    }

    public async Task CreateAddress(int membershipId, AddressModel address) {
        var membership = await GetMembership(membershipId);

        if (membership.Address != null) throw new BadHttpRequestException("Membership has an existing address.");

        _validator.ValidateAndThrow(address);

        membership.AddressId = address.Id;
        membership.Address = address;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddress(int membershipId) {
        var membership = await GetMembership(membershipId);

        var address = membership.Address
            ?? throw new BadHttpRequestException("Membership does not have an associated address.");

        _context.Addresses.Remove(address);

        membership.AddressId = null;
        membership.Address = null;

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAddress(int membershipId, UpdateAddressRequest req) {
        var membership = await GetMembership(membershipId);

        var address = membership.Address
            ?? throw new BadHttpRequestException("Membership does not have an associated address.");

        _context.Addresses.Entry(address).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(address);

        await _context.SaveChangesAsync();
    }

    private async Task<MembershipModel> GetMembership(int membershipId) {
        var membership = await _context.Memberships
            .Include(m => m.Address)
            .Where(m => m.Id == membershipId)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Associated membership not found.");

        return membership;
    }
}