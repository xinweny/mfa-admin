using Bogus;

namespace MfaApi.Modules.Address;

public class AddressFaker: Faker<AddressModel> {
    private readonly Bogus.DataSets.Address _address = new("en_CA");
    private static readonly string[] cities = [
        "Mississauga",
        "Toronto",
        "Brampton",
        "Markham",
        "Richmond Hill",
        "Vaughan",
        "Burlington",
        "Milton",
        "Oakville",
    ];
    
    public AddressFaker() {
        RuleFor(a => a.Id, f => f.Random.Guid());
        RuleFor(a => a.Line1, _ => _address.StreetAddress());
        RuleFor(
            a => a.Line2,
            f => _address.SecondaryAddress().OrNull(f)
        );
        RuleFor(c => c.City, _ => {
            var random = new Random();
            double n = random.NextDouble();

            return n < 0.8
                ? cities[0]
                : cities[random.Next(1, cities.Length)];
        });
        RuleFor(c => c.Province, _ => Province.ON);
        RuleFor(c => c.PostalCode, _ => _address.ZipCode());
    }
}