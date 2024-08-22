namespace MfaApi.Modules.Exchange;

public class GetMemberExchangesResponse {
    public required int Id { get; set; }
    public required int Year { get; set; }
    public required ExchangeType ExchangeType { get; set; }
    public required int MemberId { get; set; }
}