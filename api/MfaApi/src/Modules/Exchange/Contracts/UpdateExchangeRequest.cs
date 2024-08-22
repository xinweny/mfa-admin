namespace MfaApi.Modules.Exchange;

public class UpdateExchangeRequest {
    public int? Year { get; set; }
    public ExchangeType? ExchangeType { get; set; }
    public Guid? MemberId { get; set; }
}