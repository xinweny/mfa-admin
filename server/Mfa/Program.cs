using Microsoft.EntityFrameworkCore;

using Mfa.DbContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MfaDbContext>(options => options.UseInMemoryDatabase("Mfa"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "MFA API");

app.Run();
