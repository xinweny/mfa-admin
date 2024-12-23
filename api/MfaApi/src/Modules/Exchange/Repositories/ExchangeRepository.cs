using Microsoft.EntityFrameworkCore;
using FluentValidation;

using MfaApi.Database;
using MfaApi.Core.Sort;

namespace MfaApi.Modules.Exchange;

public class ExchangeRepository : IExchangeRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<ExchangeModel> _validator;

    public ExchangeRepository(MfaDbContext context, IValidator<ExchangeModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateExchanges(Guid memberId, IEnumerable<ExchangeModel> exchanges) {
        var member = await _context.Members
            .Include(m => m.Exchanges)
            .Where(m => m.Id == memberId)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Associated member not found.");

        foreach (ExchangeModel exchange in exchanges) {
            _validator.ValidateAndThrow(exchange);
            member.Exchanges.Add(exchange);
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteExchange(ExchangeModel exchange) {
        _context.Exchanges.Remove(exchange);

        await _context.SaveChangesAsync();
    }

    public async Task<ExchangeModel> GetExchangeById(Guid id) {
        var exchange = await _context.Exchanges
            .FindAsync(id)
            ?? throw new KeyNotFoundException("Exchange not found.");

        return exchange;
    }

    public IQueryable<ExchangeModel> GetExchangesQuery(GetExchangesRequest req) {
        var query = _context.Exchanges
            .AsNoTracking()
            .AsQueryable();

        query = query.Include(e => e.Member);

        if (!string.IsNullOrEmpty(req.Query)) {
            query = query.Where(e => e.Member != null
                && EF.Functions.ILike(e.Member.FirstName + e.Member.LastName, $"%{req.Query.Replace(" ", "")}%")
            );
        }

        if (req.ExchangeType != null) {
            query = query.Where(e => e.ExchangeType == req.ExchangeType);
        }
        
        if (req.Year != null) {
            query = query.Where(e => e.Year == req.Year);
        }

        query = query.Sort(e => e.Year, req.SortYear);

        return query;
    }

    public async Task<IEnumerable<ExchangeModel>> GetExchangesByMemberId(Guid memberId) {
        var exchanges = await _context.Exchanges
            .Where(e => e.MemberId == memberId)
            .OrderByDescending(e => e.Year)
            .ToListAsync();

        return exchanges;
    }

    public async Task UpdateExchange(ExchangeModel exchange, UpdateExchangeRequest req) {
        _context.Entry(exchange).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(exchange);

        await _context.SaveChangesAsync();
    }
}