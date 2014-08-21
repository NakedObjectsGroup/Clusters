using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class ProcessRunMap : EntityTypeConfiguration<ProcessRun>
    {
        public ProcessRunMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProcessRuns");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.WhenRun).HasColumnName("WhenRun");
            this.Property(t => t.RunMode).HasColumnName("RunMode");
            this.Property(t => t.Successful).HasColumnName("Successful");
            this.Property(t => t.AttemptNumber).HasColumnName("AttemptNumber");
            this.Property(t => t.Outcome).HasColumnName("Outcome");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ProcessDefinition_Id).HasColumnName("ProcessDefinition_Id");

            // Relationships
            this.HasOptional(t => t.ProcessDefinition)
                .WithMany(t => t.ProcessRuns)
                .HasForeignKey(d => d.ProcessDefinition_Id);

        }
    }
}
