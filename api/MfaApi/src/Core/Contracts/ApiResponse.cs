namespace MfaApi.Core.Contracts;

public class ApiResponse<T> {
    public ApiMetadata? Metadata { get; set; }
    public required T? Data { get; set; }
    public string? Message { get; set; }
}