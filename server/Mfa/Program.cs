using Microsoft.EntityFrameworkCore;

namespace Mfa;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
