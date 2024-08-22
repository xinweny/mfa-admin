namespace MfaApi.Modules.Exchange;

public interface IExchangeRepository {
    Task<IEnumerable<ExchangeModel>> GetExchanges(GetExchangesRequest req);
    Task<IEnumerable<ExchangeModel>> GetExchangesByMemberId(int memberId);
    Task<ExchangeModel> GetExchangeById(int id);
    Task CreateExchanges(int memberId, IEnumerable<ExchangeModel> exchanges);
    Task UpdateExchange(ExchangeModel exchange, UpdateExchangeRequest req);
    Task DeleteExchange(ExchangeModel exchange);
}