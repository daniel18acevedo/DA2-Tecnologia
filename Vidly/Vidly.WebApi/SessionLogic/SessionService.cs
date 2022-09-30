using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.WebApi.Domain;
using Vidly.WebApi.SessionInterface;

namespace Vidly.WebApi.SessionLogic
{
    public class SessionService : ISessionService
    {
        private readonly UserLogged userLogged;

        public SessionService(UserLogged userLogged)
        {
            this.userLogged = userLogged;
        }

        public void AuthenticateAndSaveUser(string authorizationHeader)
        {
            var userDataBase = new User
            {
                Id = "1",
                Name = "User 1",
                Permissions = new[] { "get-/api/movies", "Permission 2" }
            };

            this.userLogged.Id = userDataBase.Id;
            this.userLogged.Name = userDataBase.Name;
            this.userLogged.Permissions = userDataBase.Permissions;
        }

        public User GetUserLogged()
        {
            return new User
            {
                Id = this.userLogged.Id,
                Name = this.userLogged.Name,
                Permissions = this.userLogged.Permissions
            };
        }

        public bool IsFormatValidOfAuthorizationHeader(string authorizationHeader)
        {
            return true;
        }

        public bool IsUserAuthenticated()
        {
            return true;
        }
    }
}