using Microsoft.EntityFrameworkCore;

namespace Mfa.Database {
    public class MfaDbContext: DbContext {
        public MfaDbContext(DbContextOptions<MfaDbContext> options): base(options) {

        }

        public DbSet<Features.Users.User> Users => Set<Features.Users.User>(); 
        public DbSet<Features.Memberships.Membership> Memberships => Set<Features.Memberships.Membership>();
        public DbSet<Features.MembershipPayments.MembershipPayment> MembershipPayments => Set<Features.MembershipPayments.MembershipPayment>();
        public DbSet<Features.BoardMembers.BoardMember> BoardMembers => Set<Features.BoardMembers.BoardMember>();
        public DbSet<Features.Hosts.Host> Hosts => Set<Features.Hosts.Host>();
        public DbSet<Features.Delegates.Delegate> Delegates => Set<Features.Delegates.Delegate>();
    }
}