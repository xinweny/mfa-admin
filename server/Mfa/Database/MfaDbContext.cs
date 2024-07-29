using Microsoft.EntityFrameworkCore;

using Mfa.Features.Users;
using Mfa.Features.Memberships;
using Mfa.Features.MembershipPayments;
using Mfa.Features.Delegates;
using Mfa.Features.Hosts;
using Mfa.Features.BoardMembers;

namespace Mfa.Database;

public class MfaDbContext: DbContext {
    public MfaDbContext(DbContextOptions<MfaDbContext> options): base(options) {}

    public DbSet<User> Users => Set<User>(); 
    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<MembershipPayment> MembershipPayments => Set<MembershipPayment>();
    public DbSet<BoardMember> BoardMembers => Set<BoardMember>();
    public DbSet<Features.Hosts.Host> Hosts => Set<Features.Hosts.Host>();
    public DbSet<Features.Delegates.Delegate> Delegates => Set<Features.Delegates.Delegate>();
}