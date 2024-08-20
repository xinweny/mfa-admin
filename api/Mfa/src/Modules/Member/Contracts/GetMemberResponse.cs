using Mfa.Modules.Membership;
using Mfa.Modules.Address;

namespace Mfa.Modules.Member;

public class GetMemberResponse {
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? JoinedDate { get; set; }
    public required int MembershipId { get; set; }
    public MembershipDto? Membership { get; set; }

    public class MembershipDto {
        public class MemberDto {
            public required int Id { get; set; }
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
        }

        public required int Id { get; set; }
        public required MembershipType MembershipType { get; set; }
        public int? AddressId { get; set; }
        public AddressDto? Address { get; set; }
        public IEnumerable<MemberDto>? Members { get; set; }
    }
}