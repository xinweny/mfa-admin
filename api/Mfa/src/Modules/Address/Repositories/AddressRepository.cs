using Microsoft.EntityFrameworkCore;

using Mfa.Data;
using Mfa.Dtos;
using Mfa.Interfaces;
using Mfa.Models;

namespace Mfa.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly MfaDbContext _context;

    public AddressRepository(MfaDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Address>> GetAddresses() {
        var addressesQuery = from address in _context.Addresses
            select address;
        
        return await addressesQuery.ToListAsync();
    }

    public async Task<Address?> GetAddressById(int id) {
        var address = await _context.Addresses.FindAsync(id);

        return address;
    }

    public async Task CreateAddress(Address address)
    {
        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddress(Address address)
    {
        _context.Addresses.Remove(address);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAddress(Address address, UpdateAddressRequest req)
    {
        _context.Addresses.Entry(address).CurrentValues.SetValues(req);

        await _context.SaveChangesAsync();
    }
}