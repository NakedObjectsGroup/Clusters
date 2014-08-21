using Cluster.System.Api;
using NakedObjects;

namespace Cluster.Addresses.Api
{
    /// <summary>
    /// Result interface for a specific implementation of IPostalAddress that is created an persisted within the cluster.
    /// </summary>
    public interface IClusterManagedPostalAddress: IPostalAddress, IDomainInterface
    {
    }
}
