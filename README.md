Clusters
========

A library of re-usable object models designed to work with the Naked Objects Framework.

The library follows the 'cluster' pattern which is defined by a hard set of rules.  Each cluster provides a distinct, re-usable, piece of business functionality. The term 'cluster' has been used only to distinguish this pattern from the more general idea of re-usable 'modules' or 'components' which typically do not enforce such strict rules. 

Hard Rules
==========

1. Each Cluster has separate Api and Impl projects - the latter referencing the former.  The Api defines only the programmatic interface to the Cluster (as may used by other Clusters) - it does not define the user view of the cluster.  In general the Api exposes the minimum possible of the implementation.
2. A cluster depends on other clusters only where this clearly makes sense from a business perspective.  For example, the Emails cluster depends upon the Documents cluster as the created emails may be stored as documents.
3. A Cluster may only ever reference the Api of another Cluster; it may never reference another Impl project.  (It is recommended that this be enforced by build rules).
4. A Cluster Api will typically consist of interfaces.  It may also contain Enums, Constants, and (less commonly) static classes and methods. An Api may NOT contain any instantiable classes, whether abstract or concrete. Members on these interfaces should use only other interface types, Enums, or .NET value types.
5. The interfaces in a Cluster Api are explicitly labelled as one of three types:
- A 'service' interface defines a service for which there is an implementation in the Impl. Other clusters may expect to have an implementation of this service injected into them.
- A 'result' interface is a deliberately-restricted view of a domain type that is defined within the Impl and may be created and/or retrieved by means of a service interface method. Good practice says that result interfaces should hide data behind higher-value behaviours where possible; any properties that are exposed will be read-only except in rare cases.
- A 'role' interface is intended to be implemented by objects in other clusters in order that those objects can take advantage of behaviour implemented in the cluster. Thus, those role interfaces may form input-parameters for methods on the service API. Additionally, the cluster Impl may define ContributedActions for that role interface.

It follows from the above that:
 - Classes in a Cluster Impl may not inherit from classes in other clusters: this is a deliberate constraint.
 - Any associations between objects in different clusters must be defined by interfaces, and must therefore follow a 'polymorphic association' pattern
 
Optional Rules
==============

The following represent good practices, but are not strictly definitional to the cluster pattern:

6. Each cluster defines its own DbContext and mappings
7. Each cluster manages its own authorization via a standard pattern.  The roles used by this authorizer are defined on the cluster API.
8. Each cluster has its own test project, with emphasis on XATs that include full persistence, rather than on unit testing.  (We follow Jim Coplien's advice that unit testing is best applied only to functions that have a clear, objective, and public, definition such as an algorithm.) NOTE: We are not claiming comprehensive functional or code coverage. If you use any of the clusters in a real application you should expect to add further testing.
9. All projects in this library are set to All Warnings As Errors - so that they are warning free.
10. The complete library may be built as two NuGet Packages for the Api's and Impls respectively.  The longer term intent was that each cluster would be published as two NuGet Packages, using SemVer rules for versioning.
