using Mfa.Common.Enums;

namespace Mfa.Modules.Exchange;

public class GetExchangesRequest {
    public string? Query { get; set; }
    public int? FromYear { get; set; }
    public int? ToYear { get; set; }
    public ExchangeType? ExchangeType { get; set; }
    public SortOrder Year { get; set; }
}