using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class AbstractSubmissionHandlerMap : EntityTypeConfiguration<AbstractSubmissionHandler>
    {
        public AbstractSubmissionHandlerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AbstractSubmissionHandlers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AutoProcess).HasColumnName("AutoProcess");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.FormType_Id).HasColumnName("FormType_Id");

            // Relationships
            this.HasOptional(t => t.FormType)
                .WithMany(t => t.AbstractSubmissionHandlers)
                .HasForeignKey(d => d.FormType_Id);

        }
    }
}
