namespace MfaApi.Core.Contracts;

public class PaginationResponse {
    public int CurrentPage { get; set; }
    public int CurrentCount { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public void SetCurrentCount(int count) {
        CurrentCount = count;
    }
}