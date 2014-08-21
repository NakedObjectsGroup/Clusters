using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class MockPaymentMap : EntityTypeConfiguration<MockPayment>
    {
        public MockPaymentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MockPayments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AnalysisCodes).HasColumnName("AnalysisCodes");
        }
    }
}
