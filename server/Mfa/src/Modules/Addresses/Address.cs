using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Enums;

namespace Mfa.Models;

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
    public required Provinces Province { get; set; }

    [Required, ForeignKey(nameof(Membership))]
    public required int MembershipId { get; set; }
    public Membership? Membership { get; set; }
}