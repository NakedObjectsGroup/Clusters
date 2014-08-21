using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class AddressTypeForCountryMap : EntityTypeConfiguration<AddressTypeForCountry>
    {
        public AddressTypeForCountryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AddressTypeForCountries");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CountryISOCode).HasColumnName("CountryISOCode");
            this.Property(t => t.AddressType).HasColumnName("AddressType");
        }
    }
}
