namespace Mfa.Modules.Due;

public static class DueModule {
    public static void AddDueModule(this IServiceCollection services) {
        services.AddScoped<IDueRepository, DueRepository>();
        services.AddScoped<IDueService, DueService>();
    }
}