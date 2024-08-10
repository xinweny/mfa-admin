using Microsoft.EntityFrameworkCore;

using Mfa.Models;

namespace Mfa.Data;

public class MfaDbContext: DbContext {
    public MfaDbContext(DbContextOptions<MfaDbContext> options): base(options) {}

    public required DbSet<Member> Members { get; set; }
    public required DbSet<Membership> Memberships { get; set; }
    public required DbSet<Address> Addresses { get; set; }
    public required DbSet<MembershipPayment> MembershipPayments { get; set; }
    public required DbSet<BoardPosition> BoardPositions { get; set; }
    public required DbSet<Models.Host> Hosts { get; set; }
    public required DbSet<Models.Delegate> Delegates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Membership>()
            .HasMany(membership => membership.Members)
            .WithOne(member => member.Membership)
            .HasForeignKey(member => member.MembershipId);

        modelBuilder.Entity<Membership>()
            .HasMany(membership => membership.Payments)
            .WithOne(payment => payment.Membership)
            .HasForeignKey(payment => payment.MembershipId);
        
        modelBuilder.Entity<Membership>()
            .HasOne(membership => membership.Address)
            .WithOne(address => address.Membership)
            .HasForeignKey<Membership>(membership => membership.AddressId);

        modelBuilder.Entity<Member>()
            .HasOne(member => member.Membership)
            .WithMany(membership => membership.Members)
            .HasForeignKey(member => member.MembershipId);

        modelBuilder.Entity<Member>()
            .HasMany(member => member.BoardPositions)
            .WithOne(boardPosition => boardPosition.Member)
            .HasForeignKey(boardPosition => boardPosition.MemberId);
        
        modelBuilder.Entity<Member>()
            .HasMany(member => member.Hosts)
            .WithOne(host => host.Member)
            .HasForeignKey(host => host.MemberId);

        modelBuilder.Entity<Member>()
            .HasMany(member => member.Delegates)
            .WithOne(d => d.Member)
            .HasForeignKey(d => d.MemberId);
        
        modelBuilder.Entity<Address>()
            .HasOne(address => address.Membership)
            .WithOne(membership => membership.Address)
            .HasForeignKey<Address>(address => address.MembershipId);
    }
}