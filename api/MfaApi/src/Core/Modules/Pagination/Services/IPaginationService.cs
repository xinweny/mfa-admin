namespace MfaApi.Core.Pagination;

public interface IPaginationService {
    public Task<PaginationMetadata> GetOffsetPagination<TEntity>(
        PaginationRequest req
    ) where TEntity: class;
}