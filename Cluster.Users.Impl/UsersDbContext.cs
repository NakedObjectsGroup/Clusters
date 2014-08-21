using System.Data.Entity;
using Cluster.Users.Impl.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cluster.Users.Impl
{
    public class UsersDbContext : IdentityDbContext<IdentityUser>, IUsersDbContext
    {
        public UsersDbContext(string name) : base(name) { }
        public UsersDbContext() { }

        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MapsForUsersCluster.AddTo(modelBuilder);
        }
    }
}