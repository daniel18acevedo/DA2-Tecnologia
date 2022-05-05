using BusinessLogic.Interface;
using Domain;
using Session.Interface;

namespace BusinessLogic;
public class UserService : IUserService
{
    private readonly ISessionService _sessionService;

    public UserService(ISessionService sessionService)
    {
        this._sessionService = sessionService;
    }

    public User GetUserLogged()
    {
        var userLogged = this._sessionService.GetUserLogged();

        return new User
        {
            Id = userLogged.Id,
            Name = userLogged.Name
        };
    }
}
