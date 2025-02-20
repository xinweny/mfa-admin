using MfaApi.Modules.Address;
using MfaApi.Modules.Due;

namespace MfaApi.Modules.Membership;

public record GetMembershipsResponse {
    public required Guid Id { get; set; }
    public required MembershipType MembershipType { get; set; }
    public List<MemberDto> Members { get; set; } = [];
    public Guid? AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public required DateOnly StartDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DueDto? Due { get; set; }
    public bool IsActive { get; set; }

    public class MemberDto {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }

    public class DueDto {
        public required Guid Id { get; set; }
        public required int Year { get; set; }
        public required int AmountPaid { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public DateOnly? PaymentDate { get; set; }
    }
}