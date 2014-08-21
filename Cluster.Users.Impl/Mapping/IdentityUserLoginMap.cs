using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Cluster.Users.Impl.Mapping
{
    internal class IdentityUserLoginMap : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            // Table & Column Mappings
            this.ToTable("IdentityUserLogins");
        }
    }
}
