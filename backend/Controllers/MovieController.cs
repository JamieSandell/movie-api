// <copyright file="MovieController.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Controllers
{
    using Backend.Entities;
    using Backend.Services;
    using Microsoft.AspNetCore.Authorization;
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
        /// Search the movies dataset.
        /// </summary>
        /// <param name="title">The title to search for, search all titles if blank.</param>
        /// <param name="maxResults">Maximum number of results to return.</param>
        /// <param name="genre">Genre to filter on.</param>
        /// <param name="actor">Actor to filter on.</param>
        /// <param name="orderBy">Order by "Title" or "Date", otherwise orders by Id by default.</param>
        /// <param name="orderByDescending">Order by descending or ascending.</param>
        /// <param name="pageNumber">Page number to start on, 1 by default.</param>
        /// <param name="pageSize">Number of items per page, 10 by default.</param>
        /// <returns>The search result.</returns>
        [HttpGet("search")]
        public async Task<List<Movie>> Search(
            string? title,
            int? maxResults,
            string? genre,
            string? actor,
            string? orderBy,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10)
        {
            try // TODO: exception handling
            {
                return await this.movieService.Search( // TODO: Use model binding for optional parameters
                    title,
                    maxResults,
                    genre,
                    actor,
                    orderBy,
                    orderByDescending,
                    pageNumber,
                    pageSize);
            }
            catch
            {
                throw;
            }
        }
    }
}
