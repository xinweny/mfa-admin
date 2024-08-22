using FluentValidation;

namespace MfaApi.Modules.Exchange;

public static class ExchangeModule {
    public static void AddExchangeModule(this IServiceCollection services) {
        services.AddScoped<IExchangeRepository, ExchangeRepository>();
        services.AddScoped<IExchangeService, ExchangeService>();
        services.AddScoped<IValidator<ExchangeModel>, ExchangeValidator>();
    }
}