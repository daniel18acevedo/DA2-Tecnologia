﻿using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;
using Vidly.WebApi.Filters;
using Vidly.WebApi.Services.Sessions.Entities;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    [AuthenticationFilter]
    public sealed class MovieController : VidlyControllerBase
    {
        private static readonly List<Movie> _movies = [];

        public MovieController()
        {
        }

        [HttpPost]
        public void Create([FromBody] CreateMovieRequest? newMovie)
        {
            var userLogged = base.GetUserLogged();

            var isNotAllowed = !userLogged.Role.HasPermission(PermissionKey.CreateMovie);

            if (isNotAllowed)
                throw new Exception($"Code: Forbidden, Message: Missing permission {PermissionKey.CreateMovie}");

            // rest of code
        }
    }
}
