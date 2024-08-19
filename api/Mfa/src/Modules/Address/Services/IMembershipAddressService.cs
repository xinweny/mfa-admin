using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipAddressService {
    Task CreateAddress(int membershipId, CreateAddressRequest dto);
    Task UpdateAddress(int membershipId, UpdateAddressRequest dto);
    Task DeleteAddress(int membershipId);
}