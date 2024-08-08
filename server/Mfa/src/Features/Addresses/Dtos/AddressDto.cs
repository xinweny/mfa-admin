using Mfa.Enums;

namespace Mfa.Dtos;

public class AddressDto {
    public int Id { get; set; }
    public required string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required Provinces Province { get; set; }
    public required int MembershipId { get; set; }
}