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
        /// Search the movies.
        /// </summary>
        /// <param name="title">Search by title.</param>
        /// <param name="maxResults">Maximum number of search results to return.</param>
        /// <param name="genre">Genre to filter on.</param>
        /// <param name="actor">Actor to filter on.</param>
        /// <param name="orderBy">Order by title or release date.</param>
        /// <param name="orderByDescending">Flag to indicate ordering by descending or ascending.</param>
        /// <param name="pageNumber">Page number to start on for pagination.</param>
        /// <param name="pageSize">Number of rows per page.</param>
        /// <returns>The search result.</returns>
        public Task<List<Movie>> Search(
            string? title,
            int? maxResults,
            string? genre,
            string? actor,
            string? orderBy,
            bool orderByDescending,
            int pageNumber,
            int pageSize);
    }
}
