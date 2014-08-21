using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Cluster.Documents.Impl.Mapping
{
    public class DocumentHolderLinkMap : EntityTypeConfiguration<DocumentHolderLink>
    {
        public DocumentHolderLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("DocumentHolderLinks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AssociatedRoleObjectType).HasColumnName("AssociatedRoleObjectType");
            this.Property(t => t.AssociatedRoleObjectId).HasColumnName("AssociatedRoleObjectId");
            this.Property(t => t.Owner_Id).HasColumnName("Owner_Id");

            // Relationships
            this.HasRequired(t => t.Owner)
                .WithMany(t => t.DocumentHolderLinks)
                .HasForeignKey(d => d.Owner_Id);

        }
    }
}
