using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class CreateTaskScheduledProcessMap : EntityTypeConfiguration<CreateTaskScheduledProcess>
    {
        public CreateTaskScheduledProcessMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CreateTaskScheduledProcesses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaskName).HasColumnName("TaskName");
            this.Property(t => t.NotesToAddToTask).HasColumnName("NotesToAddToTask");
        }
    }
}
