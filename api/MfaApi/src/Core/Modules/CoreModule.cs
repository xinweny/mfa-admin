namespace MfaApi.Core;

using Pagination;

public static class CoreModule {
    public static void AddCoreModule(this IServiceCollection services) {
        services.AddScoped<IPaginationService, PaginationService>();
    }
}