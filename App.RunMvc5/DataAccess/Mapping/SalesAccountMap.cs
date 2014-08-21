using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class SalesAccountMap : EntityTypeConfiguration<SalesAccount>
    {
        public SalesAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SalesAccounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.AccountName).HasColumnName("AccountName");
            this.Property(t => t.CurrencyCode).HasColumnName("CurrencyCode");
            this.Property(t => t.ClearanceMechanism).HasColumnName("ClearanceMechanism");
        }
    }
}
