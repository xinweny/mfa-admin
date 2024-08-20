using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Mfa.Modules.Member;

namespace Mfa.Modules.Exchange;

[Table("cultural_exchanges")]
public class ExchangeModel {
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("year"), Required]
    public required int Year { get; set; }
    [Column("exchange_type")]
    public required ExchangeType ExchangeType { get; set; }

    [Column("member_id"), Required, ForeignKey(nameof(Member))]
    public required int MemberId { get; set; }
    [Required]
    public MemberModel? Member;
}