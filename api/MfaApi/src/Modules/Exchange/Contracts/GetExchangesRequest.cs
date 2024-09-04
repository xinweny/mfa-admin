using MfaApi.Core.Sort;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Exchange;

public class GetExchangesRequest: PaginationRequest {
    public string? Query { get; set; }
    public int? Year { get; set; }
    public ExchangeType? ExchangeType { get; set; }
    public SortOrder SortYear { get; set; }
}