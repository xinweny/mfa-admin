using Microsoft.EntityFrameworkCore;

using MfaApi.Core.Contracts;
using MfaApi.Database;

namespace MfaApi.Core.Services;

public class PaginationService: IPaginationService {
    private readonly MfaDbContext _context;

    public PaginationService(MfaDbContext context) {
        _context = context;
    }

    public async Task<PaginationResponse> GetOffsetPaginationAsync<TEntity>(
        PaginationRequest req
    ) where TEntity: class {
        int page = req.Page;
        int? limit = req.Limit;

        if (page <= 0 || limit <= 0) throw new BadHttpRequestException("Page number and size must be greater than 0.");

        int totalCount = await _context.Set<TEntity>()
            .AsNoTracking()
            .CountAsync();

        int totalPages = limit != null
            ? (int) Math.Ceiling(totalCount / (decimal) limit)
            : 1;

        if (page >= totalPages) throw new BadHttpRequestException($"Page number cannot exceed {totalPages}.");

        return new PaginationResponse {
            CurrentPage = page,
            TotalCount = totalCount,
            TotalPages = totalPages,
        };
    }
}