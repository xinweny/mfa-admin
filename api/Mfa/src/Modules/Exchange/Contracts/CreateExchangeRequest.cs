namespace Mfa.Modules.Exchange;

public class CreateExchangeRequest {
    public required int Year { get; set; }
    public required ExchangeType ExchangeType { get; set; }
    public required int MemberId { get; set; }
}