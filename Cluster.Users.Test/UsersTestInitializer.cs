using NakedObjects;
using System;
using System.Data.Entity;
using System.IO;
using Cluster.Users;
using System.Linq;

using Cluster.Users.Api;
using Cluster.Users.Impl;
using App.Users.Test;
using Cluster.System.Api;
using Cluster.Tasks.Api;
using Cluster.Audit.Api;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace Cluster.Users.Test
{
    public class UsersTestInitializer : DropCreateDatabaseAlways<UsersTestDbContext>
    {
       private static string sysAdmin = SystemRoles.SysAdmin;
       private static string taskAssignee = TasksRoles.TaskAssignee;
        private static string auditor = AuditRoles.Auditor;

        public UsersTestInitializer(UsersTestDbContext context)
        {
        }

        protected override void Seed(UsersTestDbContext context)
        {
            TestRoles(context);
            TestUsers(context, context); //Because UsersTestDbContext implements both roles!

            var orgs = context.MockOrganisations;
            NewMockOrganisation(orgs, "Alpha");
            NewMockOrganisation(orgs, "Beta");
            NewMockOrganisation(orgs, "Gamma");
            NewMockOrganisation(orgs, "Delta");
            NewMockOrganisation(orgs, "Epsilon");
        }

        public static MockOrganisation NewMockOrganisation(DbSet<MockOrganisation> dbSet, string name)
        {
            var org = new MockOrganisation()
            {
                Name = name
            };
            dbSet.Add(org);
            return org;
        }


        public static void TestRoles(IdentityDbContext<IdentityUser> identityContext)
        {
            NewRole(identityContext, sysAdmin);
             NewRole(identityContext, taskAssignee);
            NewRole(identityContext, auditor);
        }

        private static void NewRole(IdentityDbContext<IdentityUser> identityContext, string roleName)
        {
            var store = new RoleStore<IdentityRole>(identityContext);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = roleName };
            manager.Create(role);
        }

        public static void TestUsers(IdentityDbContext<IdentityUser> identityContext,IUsersDbContext userContext)
        {
            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(identityContext));

            NewUser(manager, userContext, "Richard", sysAdmin, taskAssignee);
            NewUser(manager, userContext, "Robbie", sysAdmin);
            NewUser(manager, userContext, "Robert", taskAssignee);
            NewUser(manager, userContext, "Charlie", sysAdmin, taskAssignee);
            NewUser(manager, userContext, "Sven");
            NewUser(manager, userContext, Cluster.Users.Api.Constants.UNKNOWN);
            NewUser(manager, userContext, "Test");

            NewUser(manager, userContext, "Test1");
            NewUser(manager, userContext, "Test2");
            NewUser(manager, userContext, "Test3");
            NewUser(manager, userContext, "Test4");
            NewUser(manager, userContext, "Test5");
        }

        public static void NewUser(UserManager<IdentityUser> manager, IUsersDbContext userContext, string userName, params string[] roles)
        {
            //Create IdentityUser
            var user = new IdentityUser() { UserName = userName };
            manager.Create(user, "password");

            //Add roles
            foreach (string role in roles)
            {
                manager.AddToRole(user.Id, role);
            }

            //Create User Details
            UserDetails details = new UserDetails()
            {
                IdentityUser = user,
                FullName = userName,
                LastModified = DateTime.Now
            };
            userContext.UserDetails.Add(details);
        }
    }
}

