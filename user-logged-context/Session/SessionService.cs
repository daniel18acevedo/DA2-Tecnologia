using Session.Interface;

namespace Session;
public class SessionService : ISessionService
{
    private UserLogged _userLogged;

    public UserLogged GetUserLogged()
    {
        return this._userLogged;
    }

    public bool isValidHeader(string header)
    {
        return true;
    }

    public void setUserLogged(string header)
    {
        this._userLogged = new UserLogged
        {
            Id = 1,
            Name = "Some name"
        };
    }
}
