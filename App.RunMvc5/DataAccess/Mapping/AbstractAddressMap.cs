using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class AbstractAddressMap : EntityTypeConfiguration<AbstractAddress>
    {
        public AbstractAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AbstractAddresses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Line1).HasColumnName("Line1");
            this.Property(t => t.Line2).HasColumnName("Line2");
            this.Property(t => t.Line3).HasColumnName("Line3");
            this.Property(t => t.Line4).HasColumnName("Line4");
            this.Property(t => t.Line5).HasColumnName("Line5");
            this.Property(t => t.ISOCode).HasColumnName("ISOCode");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
        }
    }
}
