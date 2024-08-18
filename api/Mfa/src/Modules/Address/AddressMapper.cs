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

    public static Address ToAddress(this AddressDto dto) {
        return new Address {
            Line1 = dto.Line1,
            Line2 = dto.Line2,
            Line3 = dto.Line3,
            City = dto.City,
            PostalCode = dto.PostalCode,
            Province = dto.Province,
        };
    }

    public static Address ToAddress(this CreateAddressRequest dto) {
        return new Address {
            Line1 = dto.Line1,
            Line2 = dto.Line2,
            Line3 = dto.Line3,
            City = dto.City,
            PostalCode = dto.PostalCode,
            Province = dto.Province,
        };
    }
}