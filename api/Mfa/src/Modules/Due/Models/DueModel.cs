using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Modules.Membership;

namespace Mfa.Modules.Due;

[Table("dues")]
public class DueModel {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("year"), Required]
    public required int Year { get; set; }
    [Column("payment_method"), Required]
    public required PaymentMethods PaymentMethod { get; set; }
    [Column("amount_paid"), Required]
    public required int AmountPaid { get; set; }

    [Column("membership_id"), Required, ForeignKey(nameof(Membership))]
    public required int MembershipId { get; set; }
    public MembershipModel? Membership;
}

