using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Vidly.WebApi.Filters
{
    public class AuthorizationFilter : AuthenticationFilter
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            base.OnAuthorization(context);

            if (context.Result == null)
            {
                var sessionLogic = base.GetSessionService(context);

                if (!sessionLogic.IsUserAuthenticated())
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    var userLogged = sessionLogic.GetUserLogged();

                    if (!userLogged.HasPermissions(new string[] { "get user" }))
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }
    }
}