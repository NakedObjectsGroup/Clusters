using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Documents");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.AttContent).HasColumnName("AttContent");
            this.Property(t => t.AttName).HasColumnName("AttName");
            this.Property(t => t.AttMime).HasColumnName("AttMime");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
        }
    }
}
