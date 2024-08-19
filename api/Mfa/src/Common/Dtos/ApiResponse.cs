namespace Mfa.Dtos;

public class ApiResponse<T> {
    public required T? Data { get; set; }
    public string? Message { get; set; }
}