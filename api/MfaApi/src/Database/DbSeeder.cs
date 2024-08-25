using Microsoft.EntityFrameworkCore;

using MfaApi.Modules.Membership;

namespace MfaApi.Database;

public class DbSeeder {
    private readonly ModelBuilder _modelBuilder;

    public DbSeeder(ModelBuilder modelBuilder) {
        _modelBuilder = modelBuilder;
    }

    private void Seed() {
        var memberships = new MembershipFaker()
            .Generate(20);

        _modelBuilder.Entity<MembershipModel>().HasData(memberships);
    }
}