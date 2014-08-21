using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class TelephoneDetailMap : EntityTypeConfiguration<TelephoneDetail>
    {
        public TelephoneDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TelephoneDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AreaCode).HasColumnName("AreaCode");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Preferred).HasColumnName("Preferred");
            this.Property(t => t.IsCurrent).HasColumnName("IsCurrent");
            this.Property(t => t.CountryCode_Id).HasColumnName("CountryCode_Id");

            // Relationships
            this.HasOptional(t => t.TelephoneCountryCode)
                .WithMany(t => t.TelephoneDetails)
                .HasForeignKey(d => d.CountryCode_Id);

        }
    }
}
