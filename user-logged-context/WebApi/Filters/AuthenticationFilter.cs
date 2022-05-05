using Microsoft.AspNetCore.Mvc.Filters;
using Session.Interface;

namespace WebApi.Filters;
public class AuthenticationFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var sessionService = this.GetSessionService(context);

        sessionService.setUserLogged("header");
    }

    private ISessionService GetSessionService(AuthorizationFilterContext context)
        {
            var sessionHandlerType = typeof(ISessionService);
            var sessionHandlerLogicObject = context.HttpContext.RequestServices.GetService(sessionHandlerType);
            var sessionHandler = sessionHandlerLogicObject as ISessionService;

            return sessionHandler;
        }
}