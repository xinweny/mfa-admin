using MfaApi.Core.Services;

namespace MfaApi.Core;

public static class CoreModule {
    public static void AddCoreModule(this IServiceCollection services) {
        services.AddScoped<IPaginationService, PaginationService>();
    }
}