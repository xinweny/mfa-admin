namespace Mfa.Dtos;

using Mfa.Enums;

public class UpdateMembershipRequest {
    public MembershipTypes? MembershipType { get; init; }
    public UpdateAddressDto? Address { get; set; }

    public class UpdateAddressDto {
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public Provinces? Province { get; set; }
    }
}