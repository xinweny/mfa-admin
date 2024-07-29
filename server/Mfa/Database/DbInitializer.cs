namespace Mfa.Database;

public class DbInitializer {
    private static void CreateDbIfNotExists(IHost host) {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;

        try {
            var context = services.GetRequiredService<MfaContext>();

            context.Database.EnsureCreated();
        } catch (Exception e) {
            var logger = services.GetRequiredService<ILogger<DbInitializer>>();

            logger.LogError(e, "An error occurred creating the DB.");
        }
    }
}