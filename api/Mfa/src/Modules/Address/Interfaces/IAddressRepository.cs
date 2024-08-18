using Mfa.Models;
using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IAddressRepository {
    Task<Address?> GetAddressByMembershipId(int membershipId);
    Task<Address> CreateAddress(Address address);
    Task<Address> UpdateAddress(Address address, UpdateAddressRequest dto);
    Task DeleteAddress(Address address);
}