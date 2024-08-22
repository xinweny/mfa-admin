using FluentValidation;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MfaApi.Middleware;

public class ExceptionHandlerMiddleware: IExceptionHandler {
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger) {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    ) {
        var problemDetails = new ProblemDetails {
            Detail = exception.Message,
        };

        switch (exception) {
            case BadHttpRequestException:
                problemDetails.Status = (int) HttpStatusCode.BadRequest;
                problemDetails.Title = exception.GetType().Name;
                break;
            case ValidationException:
                problemDetails.Status = (int) HttpStatusCode.BadRequest;
                problemDetails.Title = exception.GetType().Name;
                break;
            case KeyNotFoundException:
                problemDetails.Status = (int) HttpStatusCode.NotFound;
                problemDetails.Title = exception.GetType().Name;
                break;
            default:
                problemDetails.Status = (int) HttpStatusCode.InternalServerError;
                problemDetails.Title = "Internal Server Error";
                break;
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}