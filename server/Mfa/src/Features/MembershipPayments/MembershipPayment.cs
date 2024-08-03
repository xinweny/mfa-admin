using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Enums;

namespace Mfa.Models;

public class MembershipPayment {
    [Key]
    public int Id { get; set; }

    [Required]
    public required int Year { get; set; }
    [Required]
    public required PaymentMethods PaymentMethod { get; set; }
    [Required]
    public required int Amount { get; set; }

    [Required, ForeignKey(nameof(Membership))]
    public required int MembershipId { get; set; }

    public Membership? Membership;
}

