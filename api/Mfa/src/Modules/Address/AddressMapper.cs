using Mfa.Dtos;
using Mfa.Models;

namespace Mfa.Mappers;

public static class AddressMapper {
    public static AddressDto ToAddressDto(this Address address) {
        return new AddressDto {
            Line1 = address.Line1,
            Line2 = address.Line2,
            Line3 = address.Line3,
            City = address.City,
            PostalCode = address.PostalCode,
            Province = address.Province,
        };
    }

    public static Address ToAddress(this AddressDto req) {
        return new Address {
            Line1 = req.Line1,
            Line2 = req.Line2,
            Line3 = req.Line3,
            City = req.City,
            PostalCode = req.PostalCode,
            Province = req.Province,
        };
    }

    public static Address ToAddress(this CreateAddressRequest req) {
        return new Address {
            Line1 = req.Line1,
            Line2 = req.Line2,
            Line3 = req.Line3,
            City = req.City,
            PostalCode = req.PostalCode,
            Province = req.Province,
        };
    }
}