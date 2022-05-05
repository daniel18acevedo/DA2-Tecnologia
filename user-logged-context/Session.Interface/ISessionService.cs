namespace Session.Interface;
public interface ISessionService
{
    bool isValidHeader(string header);
    void setUserLogged(string header);
    UserLogged GetUserLogged();
}
