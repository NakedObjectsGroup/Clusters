using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class FormSubmissionMap : EntityTypeConfiguration<FormSubmission>
    {
        public FormSubmissionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("FormSubmissions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Submitted).HasColumnName("Submitted");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.FormContent).HasColumnName("FormContent");
            this.Property(t => t.FormName).HasColumnName("FormName");
            this.Property(t => t.FormMime).HasColumnName("FormMime");
        }
    }
}
