using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MfaApi.Modules.Membership;

namespace MfaApi.Modules.Due;

[Table("membership_dues")]
public class DueModel {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("year"), Required]
    public required int Year { get; set; }
    [Column("payment_method"), Required]
    public required PaymentMethod PaymentMethod { get; set; }
    [Column("amount_paid"), Required]
    public required int AmountPaid { get; set; }
    [Column("payment_date")]
    public DateOnly? PaymentDate { get; set; }

    [Column("membership_id"), Required, ForeignKey(nameof(Membership))]
    public required Guid MembershipId { get; set; }
    public virtual MembershipModel? Membership { get; set; }
}