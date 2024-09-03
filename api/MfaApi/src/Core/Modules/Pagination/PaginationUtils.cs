using Microsoft.EntityFrameworkCore;

namespace MfaApi.Core.Pagination;

public static class PaginationUtils {
    public static async Task<List<TEntity>> ToListWithPagination<TEntity>(
        this IQueryable<TEntity> query,
        PaginationRequest req,
        PaginationMetadata metadata
    ) where TEntity: class {
        int page = req.Page ?? 1;
        int? limit = req.Limit;

        if (page <= 0) throw new BadHttpRequestException("Page number must be greater than 0.");
        if (limit != null && limit <= 0) throw new BadHttpRequestException("Limit must be greater than 0.");

        int totalCount = await query.CountAsync();

        int totalPages = limit != null
            ? (int) Math.Ceiling(totalCount / (decimal) limit)
            : 1;

        if (page > totalPages) throw new BadHttpRequestException($"Page number cannot exceed {totalPages}.");

        metadata.CurrentPage = page;
        metadata.TotalCount = totalCount;
        metadata.TotalPages = totalPages;
        metadata.PageSize = limit;

        if (req.Page != null && req.Limit != null) query = query.Skip(((int) req.Page - 1) * (int) req.Limit);
        if (req.Limit != null) query = query.Take((int) req.Limit);

        var records = await query.ToListAsync();

        metadata.CurrentCount = records.Count;

        return records;
    }
}