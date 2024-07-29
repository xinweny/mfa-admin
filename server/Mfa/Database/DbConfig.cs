using Microsoft.EntityFrameworkCore;

namespace Mfa.Database;

public class DbConfig {
    public IConfiguration Configuration { get; }

    public DbConfig(IConfiguration configuration) {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddDbContext<MfaContext>(options => {
            options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]);
        });
    }
}