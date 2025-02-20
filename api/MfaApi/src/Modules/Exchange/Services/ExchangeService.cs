using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Exchange;

public class ExchangeService: IExchangeService {
    private readonly IExchangeRepository _exchangeRepository;

    public ExchangeService(IExchangeRepository exchangeRepository) {
        _exchangeRepository = exchangeRepository;
    }

    public async Task CreateExchanges(CreateExchangesRequest req) {
        await _exchangeRepository.CreateExchanges(req.MemberId, req.ToExchanges());
    }

    public async Task DeleteExchange(Guid id) {
        var exchange = await _exchangeRepository.GetExchangeById(id);

        await _exchangeRepository.DeleteExchange(exchange);
    }

    public async Task<IEnumerable<GetExchangesResponse>> GetExchanges(GetExchangesRequest req, PaginationMetadata metadata) {
        var query = _exchangeRepository.GetExchangesQuery(req);

        var exchanges = await query.ToListWithPagination(req, metadata);

        return exchanges.Select(e => e.ToGetExchangesResponse());
    }

    public async Task<IEnumerable<GetMemberExchangesResponse>> GetMemberExchanges(Guid memberId) {
        var exchanges = await _exchangeRepository.GetExchangesByMemberId(memberId);

        return exchanges.Select(e => e.ToGetMemberExchangesResponse());
    }

    public async Task UpdateExchange(Guid id, UpdateExchangeRequest req) {
        var exchange = await _exchangeRepository.GetExchangeById(id);

        await _exchangeRepository.UpdateExchange(exchange, req);
    }
}