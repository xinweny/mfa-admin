using Bogus;

namespace MfaApi.Modules.Due;

public class DueFaker: Faker<DueModel> {
    public DueFaker() {
        RuleFor(d => d.Id, f => f.Random.Guid());
        RuleFor(d => d.PaymentMethod, f => f.PickRandom<PaymentMethod>());
    }
}