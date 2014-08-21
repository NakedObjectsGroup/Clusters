using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster.Countries.Api
{
    public static class Constants
    {
        public const string CountryNameRegEx = @"^[a-zA-Z\s]+$";

        public const string ISOCountryCodeRegEx = @"^[A-Z\s]{1,3}$";
    }
}
