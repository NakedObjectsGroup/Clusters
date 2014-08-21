using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Transactions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DebitAmount).HasColumnName("DebitAmount");
            this.Property(t => t.CreditAmount).HasColumnName("CreditAmount");
            this.Property(t => t.AnalysisCodes).HasColumnName("AnalysisCodes");
            this.Property(t => t.Cleared).HasColumnName("Cleared");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.SalesAccount_Id).HasColumnName("SalesAccount_Id");

            // Relationships
            this.HasMany(t => t.Transactions1)
                .WithMany(t => t.Transactions)
                .Map(m =>
                    {
                        m.ToTable("DebitTransactionCreditTransactions");
                        m.MapLeftKey("CreditTransaction_Id");
                        m.MapRightKey("DebitTransaction_Id");
                    });

            this.HasOptional(t => t.SalesAccount)
                .WithMany(t => t.Transactions)
                .HasForeignKey(d => d.SalesAccount_Id);

        }
    }
}
