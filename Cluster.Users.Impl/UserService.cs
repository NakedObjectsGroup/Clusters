
using NakedObjects;
using System.ComponentModel;
using System.Linq;
using System;
using Cluster.Users.Api;
using Cluster.Tasks.Api;
using NakedObjects.Services;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cluster.Users.Impl
{
    [DisplayName("Users")]
    public class UserService : IUserService
    {
        #region Injected Services
        public IDomainObjectContainer Container { set; protected get; }
        public PolymorphicNavigator PolymorphicNavigator { set; protected get; }
        public IdentityUserRepository IdentityUserRepository { set; protected get; }
        #endregion

        [MemberOrder(40)]
        public IQueryable<UserDetails> AllUsers()
        {
            return Container.Instances<UserDetails>();
        }

        #region FindUser
        [MemberOrder(20)]
        public IUser FindUserByUserName(string name)
        {
            return FindByUserName(name);
        }

        private UserDetails FindByUserName(string userName)
        {
            UserDetails user = null;
            var allDetails = Container.Instances<UserDetails>();
            if (allDetails.Count() > 0)
            {
                user = Container.Instances<UserDetails>().Where(x => x.IdentityUser.UserName.ToUpper() == userName.ToUpper()).SingleOrDefault();
            }
            if (user != null) return user;
            //Otherwise, if username is valid, create UserDetails
            var idUser = IdentityUserRepository.FindIdentityUser(userName);
            if (idUser != null)
            {
                return CreateUserForUserName(userName, null);
            }
            Container.WarnUser(userName + " is not a known user");
            return null;
        }

        [MemberOrder(30)]
        public IQueryable<IUser> FindUsersByRealOrUserName(string nameMatch)
        {
            var match = nameMatch.Trim().ToUpper();
            return from obj in Container.Instances<UserDetails>()
                   where obj.IdentityUser.UserName.ToUpper().Contains(match) ||
                   obj.FullName.ToUpper().Contains(match)
                   select obj;
        }

        #endregion

        #region CurrentUser
        [DisplayName("Me"), MemberOrder(10)]
        public IUser CurrentUser()
        {
            return CurrentUserAsUser();
        }

        private UserDetails CurrentUserAsUser()
        {
            var userName = Container.Principal.Identity.Name;
            if (string.IsNullOrEmpty(userName))
            {
                userName = Constants.UNKNOWN;
            }
            return FindByUserName(userName);
        }

        #endregion


        [NakedObjectsIgnore]
        public IUser FindUserById(int id)
        {
            return Container.Instances<UserDetails>().Single(x => x.Id == id);
        }

        #region Organisations

        [NakedObjectsIgnore]
        public IQueryable<IUser> ListUsersForOrganisation(IUserOrg organisation)
        {
            return PolymorphicNavigator.FindOwners<UserOrganisationLink, IUserOrg, UserDetails>(organisation);
        }

        [NakedObjectsIgnore]
        public bool CanAddUser(string userName, IUserOrg toOrg, out string errorMessage)
        {
            IUser user = FindByUserName(userName);
            if (user == null)
            {
                errorMessage = "UserName " + userName + " has no UserDetails object";
                return false;
            }
            if (user.CanActFor(toOrg))
            {
                errorMessage = "User is already associated with the organisation";
                return false;
            }
            errorMessage = null;
            return true;
        }

        public IUser AddUser(string userName, IUserOrg toOrg)
        {
            UserDetails user = FindByUserName(userName);
            user.AddOrganisation(toOrg);
            return user;
        }
        #endregion

        [NakedObjectsIgnore]
        public bool CurrentUserCanActFor(IUserOrg organisation)
        {
            return CurrentUser().CanActFor(organisation);
        }

        public ICollection<IUserOrg> OrganisationsOfCurrentUser()
        {
            return CurrentUserAsUser().Organisations;
        }

        /// <summary>
        /// Assumes that an IdentityUser has already been created; this method
        /// allows specification of further details such as the FullName and Organisation(s).
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserDetails CreateUserForUserName(string userName, string fullName)
        {
            var user = Container.NewTransientInstance<UserDetails>();
            user.FullName = fullName;
            user.IdentityUser = IdentityUserRepository.FindIdentityUser(userName);
            Container.Persist(ref user);
            return user;
        }

        public string ValidateCreateUserForUserName(string userName)
        {
            var rb = new ReasonBuilder();
            var iu = IdentityUserRepository.FindIdentityUser(userName);
            if (iu == null)
            {
                return userName + " is not recognised";
            }
            var user = FindByUserName(userName);
            if (user != null)
            {
                return "A User already exists for username " + userName;
            }
            return null;
        }




    }
}
