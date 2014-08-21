using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class EmailAttachmentMap : EntityTypeConfiguration<EmailAttachment>
    {
        public EmailAttachmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EmailAttachments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AttContent).HasColumnName("AttContent");
            this.Property(t => t.AttName).HasColumnName("AttName");
            this.Property(t => t.AttMime).HasColumnName("AttMime");
            this.Property(t => t.Email_Id).HasColumnName("Email_Id");

            // Relationships
            this.HasOptional(t => t.Email)
                .WithMany(t => t.EmailAttachments)
                .HasForeignKey(d => d.Email_Id);

        }
    }
}
