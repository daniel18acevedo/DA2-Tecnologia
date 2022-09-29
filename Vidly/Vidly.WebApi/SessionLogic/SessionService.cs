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
        public void AuthenticateAndSaveUser(string authorizationHeader)
        {
            throw new Exception();
        }

        public User GetUserLogged()
        {
            return new User();
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