using Cluster.Countries.Api;
using NakedObjects;

namespace Cluster.Countries.Impl
{
    [Bounded, Immutable]
    public class Country : ICountry
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string Name { get; set; }

        public virtual string ISOCode { get; set; }     
    }
}
