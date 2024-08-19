namespace Mfa.Dtos;

public class ResponseDto<T> {
    public required T? Data { get; set; }
    public string? Message { get; set; }
}