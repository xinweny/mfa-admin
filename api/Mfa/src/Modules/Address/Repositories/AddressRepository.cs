using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Mfa.Database;

namespace Mfa.Modules.Address;

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

    public async Task<AddressModel?> GetAddressById(int id) {
        var address = await _context.Addresses.FindAsync(id);

        return address;
    }

    public async Task CreateAddress(AddressModel address) {
        _validator.ValidateAndThrow(address);

        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddress(AddressModel address) {
        _context.Addresses.Remove(address);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAddress(AddressModel address, UpdateAddressRequest req) {
        _context.Addresses.Entry(address).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(address);

        await _context.SaveChangesAsync();
    }
}