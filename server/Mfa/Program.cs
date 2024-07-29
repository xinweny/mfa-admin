using Mfa.Database;
using Microsoft.EntityFrameworkCore;

namespace Mfa;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MfaContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("postgresdb"));
        });

        var app = builder.Build();

        app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
