using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class AddressMapper {
    public static AddressDto ToAddressDto(this Address address) {
        return new AddressDto {
            Id = address.Id,
            Address1 = address.Address1,
            Address2 = address.Address2,
            Address3 = address.Address3,
            City = address.City,
            PostalCode = address.PostalCode,
            Province = address.Province,
            MembershipId = address.MembershipId,
        };
    }
}