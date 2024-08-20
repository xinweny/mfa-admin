using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Modules.Membership;

namespace Mfa.Modules.Address;

[Table("addresses")]
public class AddressModel {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("line1"), Required]
    public required string Line1 { get; set; }
    [Column("line2")]
    public string? Line2 { get; set; }
    [Column("line3")]
    public string? Line3 { get; set; }
    [Column("city"), Required]
    public required string City { get; set; }
    [Column("postal_code"), Required]
    public required string PostalCode { get; set; }
    [Column("province"), Required]
    public required Provinces Province { get; set; }

    public MembershipModel? Membership { get; set; }
}