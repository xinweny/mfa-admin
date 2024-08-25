namespace MfaApi.Modules.Address;

public class CreateAddressRequest {
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required Province Province { get; set; }
}