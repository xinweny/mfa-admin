using Microsoft.EntityFrameworkCore;

using Mfa.Models;

namespace MfaApi.Context {
    public class MfaDb: DbContext {
        public MfaDb(DbContextOptions<MfaDb> options): base(options) {

        }

        public DbSet<User> Users => Set<User>(); 
        public DbSet<Membership> Memberships => Set<Membership>();
        public DbSet<MembershipPayments> MembershipPayments => Set<MembershipPayments>();
        public DbSet<BoardMember> BoardMembers => Set<BoardMember>();
        public DbSet<Mfa.Models.Host> Hosts => Set<Mfa.Models.Host>();
        public DbSet<Mfa.Models.Delegate> Delegates => Set<Mfa.Models.Delegate>();
    }
}