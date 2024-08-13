using Mfa.Enums;

namespace Mfa.Dtos;

public class CreateMembershipRequest {
    public required MembershipTypes MembershipType { get; set; }
    public int? AddressId { get; set; }

    public IEnumerable<CreateMembershipMember>? Members { get; set; }
}