using Bogus;

namespace MfaApi.Modules.Exchange;

public class ExchangeFaker: Faker<ExchangeModel> {
    public ExchangeFaker() {
        RuleFor(e => e.Id, f => f.Random.Guid());
    }
}