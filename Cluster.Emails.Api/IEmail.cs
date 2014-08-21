using System;
using System.Collections.Generic;
using System.Linq;
using Cluster.Documents.Api;
using NakedObjects;

namespace Cluster.Emails.Api
{
    /// <summary>
    /// Result interface representing an email that is created and persisted by the Emails cluster.
    /// </summary>
    public interface IEmail : IExternalDocument
    {

    }
}
