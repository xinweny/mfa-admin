using Bogus;

namespace MfaApi.Modules.Exchange;

public class ExchangeFaker: Faker<ExchangeModel> {
    public ExchangeFaker() {
        RuleFor(m => m.Id, f => f.Random.Guid());
    }
}