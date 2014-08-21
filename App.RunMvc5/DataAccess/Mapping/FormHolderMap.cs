using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class FormHolderMap : EntityTypeConfiguration<FormHolder>
    {
        public FormHolderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("FormHolders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FormContent).HasColumnName("FormContent");
            this.Property(t => t.FormName).HasColumnName("FormName");
            this.Property(t => t.MimeType).HasColumnName("MimeType");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.FormType_Id).HasColumnName("FormType_Id");

            // Relationships
            this.HasOptional(t => t.FormType)
                .WithMany(t => t.FormHolders)
                .HasForeignKey(d => d.FormType_Id);

        }
    }
}
