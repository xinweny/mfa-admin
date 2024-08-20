namespace Mfa.Modules.Exchange;

public interface IExchangeService {
    Task<IEnumerable<GetExchangesResponse>> GetExchanges(GetExchangesRequest req);
    Task<IEnumerable<GetMemberExchangesResponse>> GetMemberExchanges(int memberId);
    Task CreateExchanges(IEnumerable<CreateExchangeRequest> req);
    Task UpdateExchange(int id, UpdateExchangeRequest req);
    Task DeleteExchange(int id);
}