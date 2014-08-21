using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class EmailDetailMap : EntityTypeConfiguration<EmailDetail>
    {
        public EmailDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("EmailDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Current).HasColumnName("Current");
            this.Property(t => t.Verified).HasColumnName("Verified");
            this.Property(t => t.Preferred).HasColumnName("Preferred");
        }
    }
}
