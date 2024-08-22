namespace MfaApi.Modules.Address;

public static class AddressMapper {
    public static AddressDto ToAddressDto(this AddressModel address) {
        return new AddressDto {
            Line1 = address.Line1,
            Line2 = address.Line2,
            Line3 = address.Line3,
            City = address.City,
            PostalCode = address.PostalCode,
            Province = address.Province,
        };
    }

    public static AddressModel ToAddress(this AddressDto req) {
        return new AddressModel {
            Line1 = req.Line1,
            Line2 = req.Line2,
            Line3 = req.Line3,
            City = req.City,
            PostalCode = req.PostalCode,
            Province = req.Province,
        };
    }

    public static AddressModel ToAddress(this CreateAddressRequest req) {
        return new AddressModel {
            Line1 = req.Line1,
            Line2 = req.Line2,
            Line3 = req.Line3,
            City = req.City,
            PostalCode = req.PostalCode,
            Province = req.Province,
        };
    }
}