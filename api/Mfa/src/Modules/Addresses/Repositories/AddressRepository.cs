using Microsoft.EntityFrameworkCore;

using Mfa.Database;

namespace Mfa.Addresses;

public class AddressRepository : IAddressRepository
{
    private readonly MfaDbContext _context;

    public AddressRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<AddressModel>> GetAddresses() {
        var addressesQuery = from address in _context.Addresses
            select address;
        
        return await addressesQuery.ToListAsync();
    }

    public async Task<AddressModel?> GetAddressById(int id) {
        var address = await _context.Addresses.FindAsync(id);

        return address;
    }

    public async Task CreateAddress(AddressModel address)
    {
        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddress(AddressModel address)
    {
        _context.Addresses.Remove(address);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAddress(AddressModel address, UpdateAddressRequest req)
    {
        _context.Addresses.Entry(address).CurrentValues.SetValues(req);

        await _context.SaveChangesAsync();
    }
}