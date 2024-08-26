using Bogus;

namespace MfaApi.Modules.Due;

public class DueFaker: Faker<DueModel> {
    public DueFaker() {
        RuleFor(m => m.Id, f => f.Random.Guid());
        RuleFor(m => m.PaymentMethod, f => f.PickRandom<PaymentMethod>());
    }
}