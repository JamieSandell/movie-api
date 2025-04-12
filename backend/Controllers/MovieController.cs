// <copyright file="MovieController.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Controllers
{
    using Backend.Entities;
    using Backend.Services;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

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
        /// Error handling for the dev environment.
        /// </summary>
        /// <param name="hostEnvironment">The host environment.</param>
        /// <returns>The problem.</returns>
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return this.NotFound();
            }

            var exceptionHandlerFeature = this.HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return this.Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        /// <summary>
        /// Error handling for production.
        /// </summary>
        /// <returns>The problem.</returns>
        [Route("/error")]
        public IActionResult HandleError() => this.Problem();

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
        /// <returns>The search notFound.</returns>
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Movie>>> Search(
            string? title,
            int? maxResults,
            string? genre,
            string? actor,
            string? orderBy,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10)
        {
            try
            {
                var movies = await this.movieService.Search(
                    title,
                    maxResults,
                    genre,
                    actor,
                    orderBy,
                    orderByDescending,
                    pageNumber,
                    pageSize);

                bool notFound = movies.IsNullOrEmpty();

                return notFound ? this.NotFound() : this.Ok(movies.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
