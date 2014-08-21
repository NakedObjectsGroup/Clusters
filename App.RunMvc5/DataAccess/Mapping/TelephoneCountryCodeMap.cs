using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ToDelete.Models.Mapping
{
    public class TelephoneCountryCodeMap : EntityTypeConfiguration<TelephoneCountryCode>
    {
        public TelephoneCountryCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TelephoneCountryCodes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ISOCountryCode).HasColumnName("ISOCountryCode");
            this.Property(t => t.CountryCallingCode).HasColumnName("CountryCallingCode");
            this.Property(t => t.InternationalCallPrefix).HasColumnName("InternationalCallPrefix");
            this.Property(t => t.AreaCodeRegexValidation).HasColumnName("AreaCodeRegexValidation");
            this.Property(t => t.NumberRegexValidation).HasColumnName("NumberRegexValidation");
            this.Property(t => t.FormatDisplayNumberFromSameCountry).HasColumnName("FormatDisplayNumberFromSameCountry");
            this.Property(t => t.FormatNumberToDialFromSameCountry).HasColumnName("FormatNumberToDialFromSameCountry");
            this.Property(t => t.FormatDisplayNumberFromOtherCountry).HasColumnName("FormatDisplayNumberFromOtherCountry");
            this.Property(t => t.FormatNumberToDialFromOtherCountry).HasColumnName("FormatNumberToDialFromOtherCountry");
        }
    }
}
