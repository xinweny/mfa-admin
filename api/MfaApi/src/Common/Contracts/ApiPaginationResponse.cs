namespace MfaApi.Common.Contracts;

public class ApiPaginationResponse<T>: ApiResponse<T> {
    public int currentPage;
    public int totalPages;
    public int count;
    public int? totalCount;
}