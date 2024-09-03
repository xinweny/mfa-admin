namespace MfaApi.Core.Pagination;

public class PaginationMetadata {
    public int? CurrentPage { get; set; }
    public int? CurrentCount { get; set; }
    public int? TotalPages { get; set; }
    public int? TotalCount { get; set; }
    public int? PageSize { get; set; }

    public void SetCurrentCount(int count) {
        CurrentCount = count;
    }
}