using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.WebApi.Domain;

namespace Vidly.WebApi.SessionInterface
{
    public interface ISessionService
    {
        bool IsFormatValidOfAuthorizationHeader(string authorizationHeader);

        void AuthenticateAndSaveUser(string authorizationHeader);

        bool IsUserAuthenticated();

        User GetUserLogged();
    }
}