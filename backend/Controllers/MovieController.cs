// <copyright file="MovieController.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Controllers
{
    using Backend.Entities;
    using Backend.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The movie controller.
    /// </summary>
    /// <param name="movieService">The movie service.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        private readonly IMovieService movieService = movieService;

        /// <summary>
        /// Get all the movies asynchronously.
        /// </summary>
        /// <returns>A list of all the movies.</returns>
        [HttpGet("getallmovies")]
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            try
            {
                return await this.movieService.GetAllMoviesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
