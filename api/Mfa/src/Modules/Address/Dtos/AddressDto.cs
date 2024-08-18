using Mfa.Enums;

namespace Mfa.Dtos;

public class AddressDto {
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required Provinces Province { get; set; }
    public required int MembershipId { get; set; }
}