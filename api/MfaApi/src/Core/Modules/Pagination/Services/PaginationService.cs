using Microsoft.EntityFrameworkCore;

using MfaApi.Database;

namespace MfaApi.Core.Pagination;

public class PaginationService: IPaginationService {
    private readonly MfaDbContext _context;

    public PaginationService(MfaDbContext context) {
        _context = context;
    }

    public async Task<PaginationMetadata> GetOffsetPagination<TEntity>(
        PaginationRequest req
    ) where TEntity: class {
        int page = req.Page ?? 1;
        int? limit = req.Limit;

        if (page <= 0) throw new BadHttpRequestException("Page number must be greater than 0.");
        if (limit != null && limit <= 0) throw new BadHttpRequestException("Limit must be greater than 0.");

        int totalCount = await _context.Set<TEntity>()
            .AsNoTracking()
            .CountAsync();

        int totalPages = limit != null
            ? (int) Math.Ceiling(totalCount / (decimal) limit)
            : 1;

        if (page > totalPages) throw new BadHttpRequestException($"Page number cannot exceed {totalPages}.");

        return new PaginationMetadata {
            CurrentPage = page,
            TotalCount = totalCount,
            TotalPages = totalPages,
            PageSize = req.Limit,
        };
    }
}