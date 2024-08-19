using Mfa.Dtos;

namespace Mfa.Interfaces;

public interface IMembershipAddressService {
    Task CreateAddress(int membershipId, CreateAddressRequest req);
    Task UpdateAddress(int membershipId, UpdateAddressRequest req);
    Task DeleteAddress(int membershipId);
}