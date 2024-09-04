using System.Linq.Expressions;

namespace MfaApi.Core.Sort;

public static class SortUtils {
    public static IQueryable<TEntity> Sort<TEntity, TKey>(
        this IQueryable<TEntity> query,
        Expression<Func<TEntity, TKey>> keyExpr,
        SortOrder? sortOrder
    ) where TEntity: class {
        if (sortOrder == null || sortOrder.Equals(SortOrder.Unsorted)) return query;

        if (sortOrder.Equals(SortOrder.Ascending)) {
            query = query.OrderBy(keyExpr);
        } else if (sortOrder.Equals(SortOrder.Descending)) {
            query = query.OrderByDescending(keyExpr);
        }

        return query;
    }
}