namespace MfaApi.Core.Contracts;

public class ApiPaginationResponse<T>: ApiResponse<T> {
    public required PaginationResponse Pagination { get; set; }
}