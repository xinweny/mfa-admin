namespace MfaApi.Modules.Exchange;

public interface IExchangeService {
    Task<IEnumerable<GetExchangesResponse>> GetExchanges(GetExchangesRequest req);
    Task<IEnumerable<GetMemberExchangesResponse>> GetMemberExchanges(Guid memberId);
    Task CreateExchanges(CreateExchangesRequest req);
    Task UpdateExchange(Guid id, UpdateExchangeRequest req);
    Task DeleteExchange(Guid id);
}