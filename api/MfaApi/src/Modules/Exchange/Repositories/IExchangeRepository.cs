namespace MfaApi.Modules.Exchange;

public interface IExchangeRepository {
    IQueryable<ExchangeModel> GetExchangesQuery(GetExchangesRequest req);
    Task<IEnumerable<ExchangeModel>> GetExchangesByMemberId(Guid memberId);
    Task<ExchangeModel> GetExchangeById(Guid id);
    Task CreateExchanges(Guid memberId, IEnumerable<ExchangeModel> exchanges);
    Task UpdateExchange(ExchangeModel exchange, UpdateExchangeRequest req);
    Task DeleteExchange(ExchangeModel exchange);
}