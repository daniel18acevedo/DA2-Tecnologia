﻿using Microsoft.AspNetCore.Mvc;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;
using Vidly.WebApi.Filters;

namespace Vidly.WebApi.Controllers.Movies
{
    [ApiController]
    [Route("movies")]
    public sealed class MovieController : ControllerBase
    {
        private static readonly List<Movie> _movies = [];

        public MovieController()
        {
        }

        // rest of code
    }
}