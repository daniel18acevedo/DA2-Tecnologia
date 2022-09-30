using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vidly.WebApi.SessionInterface;

namespace Vidly.WebApi.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Result = new ObjectResult(new { Message = "Authorization header is missing" })
                {
                    StatusCode = 401
                };
            }
            else
            {
                var sessionLogic = this.GetSessionService(context);

                var authorizationHeaderIsValid = sessionLogic.IsFormatValidOfAuthorizationHeader(authorizationHeader);

                if (!authorizationHeaderIsValid)
                {
                    context.Result = new ObjectResult(new { Message = "Authorization header format incorrect" })
                    {
                        StatusCode = 401
                    };
                }
                else
                {
                    try
                    {
                        sessionLogic.AuthenticateAndSaveUser(authorizationHeader);
                    }
                    catch (Exception ex)
                    {
                        context.Result = new ObjectResult(new { Message = "Authorization header invalid" })
                        {
                            StatusCode = 401
                        };
                    }
                }
            }


        }

        protected ISessionService GetSessionService(AuthorizationFilterContext context)
        {
            var sessionHandlerType = typeof(ISessionService);
            var sessionHandlerLogicObject = context.HttpContext.RequestServices.GetService(sessionHandlerType);
            var sessionHandler = sessionHandlerLogicObject as ISessionService;

            return sessionHandler;
        }
    }
}