using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class AbstractNameMap : EntityTypeConfiguration<AbstractName>
    {
        public AbstractNameMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AbstractNames");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Searchable).HasColumnName("Searchable");
            this.Property(t => t.Prefix).HasColumnName("Prefix");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.InformalFirstName).HasColumnName("InformalFirstName");
            this.Property(t => t.MiddleInitial).HasColumnName("MiddleInitial");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Suffix).HasColumnName("Suffix");
        }
    }
}
