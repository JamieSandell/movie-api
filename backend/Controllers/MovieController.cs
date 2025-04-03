﻿// <copyright file="MovieController.cs" company="Jamie Sandell">
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
        /// <param name="pageNumber">Page number to start on, 1 by default.</param>
        /// <param name="pageSize">Number of items per page, 10 by default.</param>
        /// <returns>The search result.</returns>
        [HttpGet("search")]
        public async Task<List<Movie>> Search(
            string? title,
            int? maxResults,
            int pageNumber = 1,
            int pageSize = 10)
        {
            try // TODO: exception handling
            {
                return await this.movieService.Search( // TODO: Use model binding for optional parameters
                    title,
                    maxResults,
                    pageNumber,
                    pageSize);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get all the movies asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number to start on.</param>
        /// <param name="pageSize">Max results to show on the page.</param>
        /// <param name="genre">The genre to filter on. Empty string to ignore.</param>
        /// <param name="actor">Actor to filter on, delimit with ;.</param>
        /// <param name="sortByTitle">Sort by title flag.</param>
        /// <param name="sortByReleaseDate">Sort by release date flag.</param>
        /// <param name="descending">Sort by descending flag.</param>
        /// <returns>A list of all the movies.</returns>
        [HttpGet("getallmovies")]
        [AllowAnonymous]
        public async Task<List<Movie>> GetAllMoviesAsync(
            int pageNumber,
            int pageSize,
            string? genre,
            string? actor,
            bool sortByTitle,
            bool sortByReleaseDate,
            bool descending)
        {
            try
            {
                return await this.movieService.GetAllMoviesAsync(pageNumber, pageSize, genre, actor, sortByTitle, sortByReleaseDate, descending);
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
        /// <param name="searchLimit">Limit the number of search results.</param>
        /// <param name="genre">The genre to filter on. Empty string to ignore.</param>
        /// <returns>A list of movies that matched the title.</returns>
        [HttpGet("searchbytitle")]
        [AllowAnonymous]
        public async Task<List<Movie>> SearchMovieByTitleAsync(string title, int searchLimit, string? genre)
        {
            try
            {
                return await this.movieService.SearchMovieByTitleAsync(title, searchLimit, genre);
            }
            catch
            {
                throw;
            }
        }
    }
}
