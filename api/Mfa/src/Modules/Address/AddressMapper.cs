using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class AddressMapper {
    public static AddressDto ToAddressDto(this Address address) {
        return new AddressDto {
            Id = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Line3 = address.Line3,
            City = address.City,
            PostalCode = address.PostalCode,
            Province = address.Province,
            MembershipId = address.MembershipId,
        };
    }
}