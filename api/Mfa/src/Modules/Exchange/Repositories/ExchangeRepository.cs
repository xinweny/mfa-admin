using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Mfa.Database;
using Mfa.Common.Enums;
using Mfa.Modules.Member;

namespace Mfa.Modules.Exchange;

public class ExchangeRepository : IExchangeRepository
{
    private readonly MfaDbContext _context;
    private readonly IValidator<ExchangeModel> _validator;

    public ExchangeRepository(MfaDbContext context, IValidator<ExchangeModel> validator) {
        _context = context;
        _validator = validator;
    }

    public async Task CreateExchange(ExchangeModel exchange)
    {
        _validator.ValidateAndThrow(exchange);

        _context.Exchanges.Add(exchange);

        await _context.SaveChangesAsync();
    }

    public async Task CreateExchanges(IEnumerable<ExchangeModel> exchanges)
    {
        foreach (ExchangeModel exchange in exchanges) {
            _validator.ValidateAndThrow(exchange);
        }

        _context.Exchanges.AddRange(exchanges);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteExchange(ExchangeModel exchange)
    {
        _context.Exchanges.Remove(exchange);

        await _context.SaveChangesAsync();
    }

    public async Task<ExchangeModel?> GetExchangeById(int id)
    {
        var exchange = await _context.Exchanges.FindAsync(id);

        return exchange;
    }

    public async Task<IEnumerable<ExchangeModel>> GetExchanges(GetExchangesRequest req)
    {
        var query = _context.Exchanges.AsQueryable();

        query.Include(e => e.Member);

        if (!string.IsNullOrEmpty(req.Query)) {
            query.Where(e =>
                e.Member != null
                    ? e.Member.DoesFullNameContainQuery(req.Query)
                    : false
            );
        }

        if (req.ExchangeType != null) query.Where(e => e.ExchangeType == req.ExchangeType);
        if (req.FromYear != null) query.Where(e => e.Year >= req.FromYear);
        if (req.ToYear != null) query.Where(e => e.Year <= req.ToYear);

        if (req.Year == SortOrder.Ascending) {
            query.OrderBy(e => e.Year);
        } else if (req.Year == SortOrder.Descending) {
            query.OrderByDescending(e => e.Year);
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<ExchangeModel>> GetExchangesByMemberId(int memberId)
    {
        var exchanges = await _context.Exchanges
            .Where(e => e.MemberId == memberId)
            .OrderByDescending(e => e.Year)
            .ToListAsync();

        return exchanges;
    }

    public async Task UpdateExchange(ExchangeModel exchange, UpdateExchangeRequest req)
    {
        _context.Entry(exchange).CurrentValues.SetValues(req);

        _validator.ValidateAndThrow(exchange);

        await _context.SaveChangesAsync();
    }
}