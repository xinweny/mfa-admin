using Microsoft.EntityFrameworkCore;

using Mfa.Infrastructure.Users;
using Mfa.Infrastructure.Memberships;
using Mfa.Infrastructure.Addresses;
using Mfa.Infrastructure.MembershipPayments;
using Mfa.Infrastructure.Delegates;
using Mfa.Infrastructure.Hosts;
using Mfa.Infrastructure.BoardPositions;

namespace Mfa.Database;

public class MfaDbContext: DbContext {
    public MfaDbContext(DbContextOptions<MfaDbContext> options): base(options) {}

    public required DbSet<User> Users { get; set; }
    public required DbSet<Membership> Memberships { get; set; }
    public required DbSet<Address> Addresses { get; set; }
    public required DbSet<MembershipPayment> MembershipPayments { get; set; }
    public required DbSet<BoardPosition> BoardPositions { get; set; }
    public required DbSet<Infrastructure.Hosts.Host> Hosts { get; set; }
    public required DbSet<Infrastructure.Delegates.Delegate> Delegates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Membership>()
            .HasMany(membership => membership.Users)
            .WithOne(user => user.Membership)
            .HasForeignKey(user => user.MembershipId);

        modelBuilder.Entity<Membership>()
            .HasMany(membership => membership.Payments)
            .WithOne(payment => payment.Membership)
            .HasForeignKey(payment => payment.MembershipId);
        
        modelBuilder.Entity<Membership>()
            .HasOne(membership => membership.Address)
            .WithOne(address => address.Membership)
            .HasForeignKey<Membership>(membership => membership.AddressId);

        modelBuilder.Entity<User>()
            .HasOne(user => user.Membership)
            .WithMany(membership => membership.Users)
            .HasForeignKey(user => user.MembershipId);

        modelBuilder.Entity<User>()
            .HasMany(user => user.BoardPositions)
            .WithOne(boardPosition => boardPosition.User)
            .HasForeignKey(boardPosition => boardPosition.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(user => user.Hosts)
            .WithOne(host => host.User)
            .HasForeignKey(host => host.UserId);

        modelBuilder.Entity<User>()
            .HasMany(user => user.Delegates)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId);
        
        modelBuilder.Entity<Address>()
            .HasOne(address => address.Membership)
            .WithOne(membership => membership.Address)
            .HasForeignKey<Address>(address => address.MembershipId);
    }
}