using Microsoft.EntityFrameworkCore;

using Mfa.Modules.Member;
using Mfa.Modules.BoardMember;
using Mfa.Modules.Address;
using Mfa.Modules.Membership;
using Mfa.Modules.Exchange;
using Mfa.Modules.Due;
using Mfa.Modules.User;

namespace Mfa.Database;

public class MfaDbContext: DbContext {
    public MfaDbContext(DbContextOptions<MfaDbContext> options): base(options) {}

    public required DbSet<MemberModel> Members { get; set; }
    public required DbSet<MembershipModel> Memberships { get; set; }
    public required DbSet<AddressModel> Addresses { get; set; }
    public required DbSet<DueModel> Dues { get; set; }
    public required DbSet<BoardMemberModel> BoardMembers { get; set; }
    public required DbSet<ExchangeModel> Exchanges { get; set; }
    public required DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<MembershipModel>()
            .HasMany(membership => membership.Members)
            .WithOne(member => member.Membership)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(member => member.MembershipId);

        modelBuilder.Entity<MembershipModel>()
            .HasMany(membership => membership.Dues)
            .WithOne(due => due.Membership)
            .HasForeignKey(due => due.MembershipId);
        
        modelBuilder.Entity<MembershipModel>()
            .HasOne(membership => membership.Address)
            .WithOne(address => address.Membership)
            .HasForeignKey<MembershipModel>(membership => membership.AddressId);

        modelBuilder.Entity<MemberModel>()
            .HasOne(member => member.Membership)
            .WithMany(membership => membership.Members)
            .HasForeignKey(member => member.MembershipId);

        modelBuilder.Entity<MemberModel>()
            .HasMany(member => member.BoardPosition)
            .WithOne(boardPosition => boardPosition.Member)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(boardPosition => boardPosition.MemberId);
        
        modelBuilder.Entity<MemberModel>()
            .HasMany(member => member.Exchanges)
            .WithOne(exchange => exchange.Member)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(host => host.MemberId);
    }
}