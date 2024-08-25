using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Address;

[Table("addresses")]
public class AddressModel {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("line1"), Required]
    public required string Line1 { get; set; }
    [Column("line2")]
    public string? Line2 { get; set; }
    [Column("city"), Required]
    public required string City { get; set; }
    [Column("postal_code"), Required]
    public required string PostalCode { get; set; }
    [Column("province"), Required]
    public required Province Province { get; set; }

    public virtual MembershipModel? Membership { get; set; }
}