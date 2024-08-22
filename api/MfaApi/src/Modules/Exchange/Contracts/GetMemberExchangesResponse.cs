namespace MfaApi.Modules.Exchange;

public class GetMemberExchangesResponse {
    public required Guid Id { get; set; }
    public required int Year { get; set; }
    public required ExchangeType ExchangeType { get; set; }
    public required Guid MemberId { get; set; }
}