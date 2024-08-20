namespace Mfa.Modules.Exchange;

public interface IExchangeRepository {
    Task<IEnumerable<ExchangeModel>> GetExchanges(GetExchangesRequest req);
    Task<IEnumerable<ExchangeModel>> GetExchangesByMemberId(int memberId);
    Task<ExchangeModel?> GetExchangeById(int id);
    Task CreateExchange(ExchangeModel exchange);
    Task CreateExchanges(IEnumerable<ExchangeModel> exchanges);
    Task UpdateExchange(ExchangeModel exchange, UpdateExchangeRequest req);
    Task DeleteExchange(ExchangeModel exchange);
}