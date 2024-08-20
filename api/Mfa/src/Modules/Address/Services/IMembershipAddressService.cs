namespace Mfa.Modules.Address;

public interface IMembershipAddressService {
    Task CreateAddress(int membershipId, CreateAddressRequest req);
    Task UpdateAddress(int membershipId, UpdateAddressRequest req);
    Task DeleteAddress(int membershipId);
}