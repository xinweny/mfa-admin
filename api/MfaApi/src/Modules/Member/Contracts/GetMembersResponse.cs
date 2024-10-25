using MfaApi.Modules.Membership;
using MfaApi.Modules.Address;

namespace MfaApi.Modules.Member;

public class GetMembersResponse {
    public required Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? JoinedDate { get; set; }
    public required Guid MembershipId { get; set; }
    public MembershipDto? Membership { get; set; }

    public class MembershipDto {
        public required Guid Id { get; set; }
        public required MembershipType MembershipType { get; set; }
        public Guid? AddressId { get; set; }
        public AddressDto? Address { get; set; }
        public required bool IsActive { get; set; }
    }
}