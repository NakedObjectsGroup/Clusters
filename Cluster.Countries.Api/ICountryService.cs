using System.Collections.Generic;
using System.Linq;

namespace Cluster.Countries.Api
{
    public interface ICountryService
    {
        IQueryable<ICountry> AllCountries();

        IQueryable<ICountry> FindCountryByName(string match);

        ICountry FindCountryByCode(string exactMatch);

        /// <summary>
        /// Returns the default country for the application (typically the country in which the organisation is based).
        /// For a truely global application this has no meaning.
        /// </summary>
        ICountry DefaultCountry();
    }
}
