namespace MfaApi.Core.Pagination;

public static class PaginationUtils {
    public static IQueryable<TEntity> Paginate<TEntity>(
        this IQueryable<TEntity> query,
        PaginationRequest req
    ) where TEntity: class {
        if (req.Page != null && req.Limit != null) query = query.Skip(((int) req.Page - 1) * (int) req.Limit);
        if (req.Limit != null) query = query.Take((int) req.Limit);

        return query;
    }
}