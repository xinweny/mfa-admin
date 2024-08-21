using System.Net;
using Microsoft.IdentityModel.Tokens;

public class IPWhitelistMiddleware {
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public IPWhitelistMiddleware(RequestDelegate next, IConfiguration configuration) {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context) {
        var remoteIP = context.Connection.RemoteIpAddress;
        var allowedIPs = _configuration.GetSection("AdminSafeList").Get<string[]>();

        if (allowedIPs.IsNullOrEmpty()) {
            await _next(context);
            return;
        }

        if (remoteIP == null || !IPAddress.IsLoopback(remoteIP) && !allowedIPs!.Contains(remoteIP.ToString())) {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

            await context.Response.WriteAsync("Access forbidden");

            return;
        }

        await _next(context);
    }
}