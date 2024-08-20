namespace Mfa.Modules.Exchange;

public class ExchangeService: IExchangeService {
    private readonly IExchangeRepository _exchangeRepository;

    public ExchangeService(IExchangeRepository exchangeRepository) {
        _exchangeRepository = exchangeRepository;
    }

    public async Task CreateExchanges(IEnumerable<CreateExchangeRequest> req)
    {
        await _exchangeRepository.CreateExchanges(req.Select(e => e.ToExchange()));
    }

    public async Task DeleteExchange(int id)
    {
        var exchange = await _exchangeRepository.GetExchangeById(id)
            ?? throw new KeyNotFoundException("Exchange not found.");

        await _exchangeRepository.DeleteExchange(exchange);
    }

    public async Task<IEnumerable<GetExchangesResponse>> GetExchanges(GetExchangesRequest req)
    {
        var exchanges = await _exchangeRepository.GetExchanges(req);

        return exchanges.Select(e => e.ToGetExchangesResponse());
    }

    public async Task<IEnumerable<GetMemberExchangesResponse>> GetMemberExchanges(int memberId)
    {
        var exchanges = await _exchangeRepository.GetExchangesByMemberId(memberId);

        return exchanges.Select(e => e.ToGetMemberExchangesResponse());
    }

    public async Task UpdateExchange(int id, UpdateExchangeRequest req)
    {
        var exchange = await _exchangeRepository.GetExchangeById(id)
            ?? throw new KeyNotFoundException("Exchange not found.");

        await _exchangeRepository.UpdateExchange(exchange, req);
    }
}