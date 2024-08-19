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
        var addressQuery = from address in _context.Addresses
            select address;
        
        return await addressQuery.ToListAsync();
    }

    public async Task<Address?> GetAddressById(int id) {
        var address = await _context.Addresses.FindAsync(id);

        return address;
    }

    public async Task<Address> CreateAddress(Address address)
    {
        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();

        return address;
    }

    public async Task DeleteAddress(Address address)
    {
        _context.Addresses.Remove(address);

        await _context.SaveChangesAsync();
    }

    public async Task<Address> UpdateAddress(Address address, UpdateAddressRequest dto)
    {
        _context.Addresses.Entry(address).CurrentValues.SetValues(dto);

        await _context.SaveChangesAsync();

        return address;
    }
}