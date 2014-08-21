using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class ProcessDefinitionMap : EntityTypeConfiguration<ProcessDefinition>
    {
        public ProcessDefinitionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ProcessDefinitions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ClassToInvoke).HasColumnName("ClassToInvoke");
            this.Property(t => t.ProcessInstanceId).HasColumnName("ProcessInstanceId");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.FirstRun).HasColumnName("FirstRun");
            this.Property(t => t.Frequency).HasColumnName("Frequency");
            this.Property(t => t.NextRun).HasColumnName("NextRun");
            this.Property(t => t.LastRun).HasColumnName("LastRun");
            this.Property(t => t.NumberOfAttemptsEachRun).HasColumnName("NumberOfAttemptsEachRun");
        }
    }
}
