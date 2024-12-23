namespace MfaApi.Modules.Exchange;

public class CreateExchangesRequest {
    public required List<CreateExchangeRequest> Exchanges { get; set; }
    public required Guid MemberId { get; set; }

    public class CreateExchangeRequest {
        public required int Year { get; set; }
        public required ExchangeType ExchangeType { get; set; }
    }
}