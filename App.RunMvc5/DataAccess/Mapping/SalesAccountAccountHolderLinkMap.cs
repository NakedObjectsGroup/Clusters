using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class SalesAccountAccountHolderLinkMap : EntityTypeConfiguration<SalesAccountAccountHolderLink>
    {
        public SalesAccountAccountHolderLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SalesAccountAccountHolderLinks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AssociatedRoleObjectType).HasColumnName("AssociatedRoleObjectType");
            this.Property(t => t.AssociatedRoleObjectId).HasColumnName("AssociatedRoleObjectId");

            // Relationships
            this.HasRequired(t => t.SalesAccount)
                .WithOptional(t => t.SalesAccountAccountHolderLink);

        }
    }
}
