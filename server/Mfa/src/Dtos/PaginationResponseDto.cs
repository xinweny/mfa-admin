namespace Mfa.Dtos;

public struct PaginationData {
    public int currentPage;
    public int totalPages;
    public int count;
    public int? totalCount;
}

public class PaginationResponseDto<T>: ResponseDto<T> {
    public PaginationData Pagination { get; set; }
}