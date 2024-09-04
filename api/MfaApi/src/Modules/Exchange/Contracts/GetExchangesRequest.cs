using MfaApi.Core.Constants;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Exchange;

public class GetExchangesRequest: PaginationRequest {
    public string? Query { get; set; }
    public int? FromYear { get; set; }
    public int? ToYear { get; set; }
    public ExchangeType? ExchangeType { get; set; }
    public SortOrder SortYear { get; set; }
}