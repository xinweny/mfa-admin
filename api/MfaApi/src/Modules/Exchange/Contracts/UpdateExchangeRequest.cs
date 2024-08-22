namespace MfaApi.Modules.Exchange;

public class UpdateExchangeRequest {
    public int? Year { get; set; }
    public ExchangeType? ExchangeType { get; set; }
    public int? MemberId { get; set; }
}