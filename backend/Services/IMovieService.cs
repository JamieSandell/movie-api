// <copyright file="IMovieService.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Entities;

    /// <summary>
    /// Interface for the movie service.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Get all the movies asynchronously.
        /// </summary>
        /// <param name="pageNumber">Page number to start on.</param>
        /// <param name="pageSize">Number of items to display per page.</param>
        /// <returns>A list of all the movies.</returns>
        public Task<List<Movie>> GetAllMoviesAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Search for a movie by title asynchronously.
        /// </summary>
        /// <param name="title">The title of the movie to search for.</param>
        /// <param name="searchLimit">Limit the number of search results.</param>
        /// <returns>A list of movies that match the search.</returns>
        public Task<List<Movie>> SearchMovieByTitleAsync(string title, int searchLimit);
    }
}
