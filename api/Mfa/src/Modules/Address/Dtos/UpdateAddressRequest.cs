using Mfa.Enums;

namespace Mfa.Dtos;

public class UpdateAddressRequest {
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public Provinces? Province { get; set; }
}