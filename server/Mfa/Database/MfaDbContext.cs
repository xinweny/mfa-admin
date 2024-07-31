using Microsoft.EntityFrameworkCore;

using Mfa.Infrastructure.Users;
using Mfa.Infrastructure.Memberships;
using Mfa.Infrastructure.Addresses;
using Mfa.Infrastructure.MembershipPayments;
using Mfa.Infrastructure.Delegates;
using Mfa.Infrastructure.Hosts;
using Mfa.Infrastructure.BoardMembers;

namespace Mfa.Database;

public class MfaDbContext: DbContext {
    public MfaDbContext(DbContextOptions<MfaDbContext> options): base(options) {}

    public DbSet<User> Users => Set<User>(); 
    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<MembershipPayment> MembershipPayments => Set<MembershipPayment>();
    public DbSet<BoardMember> BoardMembers => Set<BoardMember>();
    public DbSet<Infrastructure.Hosts.Host> Hosts => Set<Infrastructure.Hosts.Host>();
    public DbSet<Infrastructure.Delegates.Delegate> Delegates => Set<Infrastructure.Delegates.Delegate>();
}