namespace MfaApi.Common.Contracts;

public class PaginationRequest {
    public required int Offset { get; set; }
    public required int Limit { get; set; }
}