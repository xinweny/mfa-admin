using Microsoft.EntityFrameworkCore;

using MfaApi.Modules.Member;
using MfaApi.Modules.BoardMember;
using MfaApi.Modules.Address;
using MfaApi.Modules.Membership;
using MfaApi.Modules.Exchange;
using MfaApi.Modules.Due;
using MfaApi.Modules.User;

namespace MfaApi.Database;

public class MfaDbContext: DbContext {
    private readonly IWebHostEnvironment _env;

    public MfaDbContext(
        DbContextOptions<MfaDbContext> options,
        IWebHostEnvironment env
    ): base(options) {
        _env = env;
    }

    public required DbSet<MemberModel> Members { get; set; }
    public required DbSet<MembershipModel> Memberships { get; set; }
    public required DbSet<AddressModel> Addresses { get; set; }
    public required DbSet<DueModel> Dues { get; set; }
    public required DbSet<BoardMemberModel> BoardMembers { get; set; }
    public required DbSet<ExchangeModel> Exchanges { get; set; }
    public required DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("PGSQL_CONNECTION_STRING"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new MembershipConfiguration());
        modelBuilder.ApplyConfiguration(new MemberConfiguration());

        if (_env.IsDevelopment()) {
            modelBuilder.Seed();
        }
    }
}