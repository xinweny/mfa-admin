using MfaApi.Core.Contracts;

namespace MfaApi.Core.Services;

interface IPaginationService {
    public Task<PaginationResponse> GetOffsetPaginationAsync<TEntity>(
        PaginationRequest req
    ) where TEntity: class;
}