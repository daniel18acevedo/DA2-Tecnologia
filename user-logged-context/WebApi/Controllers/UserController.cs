using BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers;

[ApiController]
[Route("users")]
[AuthenticationFilter]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }
    public IActionResult Get()
    {
        var userLogged = this._userService.GetUserLogged();
        return Ok(userLogged);
    }
}
