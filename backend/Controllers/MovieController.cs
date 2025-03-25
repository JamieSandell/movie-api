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
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
    public class MovieController(IMovieService movieService) : ControllerBase
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
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

        /// <summary>
        /// Searches a movie by title asynchronously.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <returns>A list of movies that matched the title.</returns>
        [HttpGet("searchbytitle")]
        public async Task<List<Movie>> SearchMovieByTitleAsync(string title)
        {
            try
            {
                return await this.movieService.SearchMovieByTitleAsync(title);
            }
            catch
            {
                throw;
            }
        }
    }
}
