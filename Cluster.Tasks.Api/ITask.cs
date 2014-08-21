using Cluster.System.Api;
using NakedObjects;

namespace Cluster.Tasks.Api
{
    /// <summary>
    /// Result interface for a Task created/retrieved by the cluster
    /// </summary>
    [Named("Task")]
    public interface ITask: IDomainInterface
    {
    }
}
