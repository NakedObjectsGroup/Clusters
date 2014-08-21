using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class MockPersistentSPMap : EntityTypeConfiguration<MockPersistentSP>
    {
        public MockPersistentSPMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MockPersistentSPs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SpecificOutcome).HasColumnName("SpecificOutcome");
        }
    }
}
