using System.ComponentModel.DataAnnotations;

namespace Mfa.Features.Addresses;

public class Address {
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }
    
    [Required]
    public required string City { get; set; }

    [Required]
    public required string PostalCode { get; set; }

    [Required]
    public required int MembershipId { get; set; }
}