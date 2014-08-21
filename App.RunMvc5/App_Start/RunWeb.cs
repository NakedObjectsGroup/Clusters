using App.DataAccess;
using NakedObjects.Boot;
using NakedObjects.Core.Context;
using NakedObjects.Core.NakedObjectsSystem;
using NakedObjects.EntityObjectStore;
using NakedObjects.Web.Mvc;
using NakedObjects.Web.Mvc.Helpers;

using NakedObjects.Reflector.Security;
using NakedObjects.Security;
using NakedObjects.Services;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Cluster.Tasks.Impl;
using Cluster.Forms.Impl;
using Cluster.Users;
using Cluster.Addresses.Impl;
using Cluster.Tasks.Test;
using Cluster.Names.Impl;
using Cluster.Addresses.Test;
using Cluster.Documents.Impl;
using Cluster.Documents.Test;
using Cluster.Users.Impl;
using Cluster.Emails.Test;
using Cluster.Emails.Impl;
using Cluster.System.Impl;
using Cluster.System.Mock;
using Cluster.Accounts.Impl;
using NakedObjects.Reflector.Audit;
using Cluster.Audit.Impl;
using NakedObjects.Snapshot;
//using Cluster.Users.Test;
using Cluster.Accounts.Test;
using Cluster.Forms.Test;
using Cluster.Batch.Impl;

namespace RunMvc5.App_Start
{
    public class RunWeb : RunMvc
    {
        protected override NakedObjectsContext Context
        {
            get { return HttpContextContext.CreateInstance(); }
        }

        protected override IServicesInstaller MenuServices
        {
            get
            {
                return new ServicesInstaller(
                    new AccountsService(),
                    new UserService(),
                    new IdentityUserRepository(),
                    new AuditService(),
                    new TaskRepository(),
                    new DocumentService(),
                    new EmailService(),
                    new BatchRepository(),
                    new BatchProcessRunner()
                    //new AddressService(),
                    //new ProcessDefinitionRepository(),
                    //new CustomerAccountsService(),
                    //new FormRepository(),
                    //new FormService(),
                    //new MockFormInitiator()
                    );
            }
        }

        protected override IServicesInstaller ContributedActions
        {
            get
            {
                return new ServicesInstaller(new TaskContributedActions(), new AuditContributedActions());
            }
        }

        protected override IServicesInstaller SystemServices
        {
            get
            {
                return new ServicesInstaller(
                    new AdjustableClock(),
                    new PolymorphicNavigator(),
                    new NameService(),
                    new NakedObjectsEmailSender(),
                    new XmlSnapshotService(),
                    new SimpleCustomerAccountNumberCreator(),
                    new FormService()
                    );
            }
        }

        protected override IAuthorizerInstaller Authorizer
        {
            get
            {
                return new CustomAuthorizerInstaller(
                    new DefaultAuthorizerForSysAdminOnly(),
                    new AuditAuthorizer(),
                    new TasksAuthorizer(),
                    new UsersAuthorizer()
                    );
            }
        }

        protected override IAuditorInstaller Auditor
        {
            get
            {
                return new AuditInstaller(new DefaultAuditor());
            }
        }

        protected override IObjectPersistorInstaller Persistor
        {
            get
            {
                var installer = new EntityPersistorInstaller() { EnforceProxies = false };
                Database.SetInitializer(new AppInitializer());
                installer.UsingCodeFirstContext(() => new AppDbContext());
                return installer;
            }
        }

        public static void Run()
        {
            new RunWeb().Start();
        }
    }
}