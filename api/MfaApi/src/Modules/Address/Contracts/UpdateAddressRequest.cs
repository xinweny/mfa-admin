namespace MfaApi.Modules.Address;

public class UpdateAddressRequest {
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public Province? Province { get; set; }
}