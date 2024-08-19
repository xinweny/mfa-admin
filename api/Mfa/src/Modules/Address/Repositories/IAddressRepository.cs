using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IAddressRepository {
    Task<IEnumerable<Address>> GetAddresses();
    Task<Address?> GetAddressById(int id);
    Task<Address> CreateAddress(Address address);
    Task<Address> UpdateAddress(Address address, UpdateAddressRequest dto);
    Task DeleteAddress(Address address);
}