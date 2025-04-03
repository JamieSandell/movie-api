﻿// <copyright file="IMovieService.cs" company="Jamie Sandell">
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
        /// <param name="pageNumber">Page number to start on for pagination.</param>
        /// <param name="pageSize">Number of rows per page.</param>
        /// <returns>The search result.</returns>
        public Task<List<Movie>> Search(
            string? title,
            int? maxResults,
            int pageNumber,
            int pageSize);

        /// <summary>
        /// Get all the movies asynchronously.
        /// </summary>
        /// <param name="pageNumber">Page number to start on.</param>
        /// <param name="pageSize">Number of items to display per page.</param>
        /// <param name="genre">Genre to filter on, null to ignore.</param>
        /// <param name="actor">Actor to filter on, delimit with ;.</param>
        /// <param name="sortByTitle">Sort by title flag.</param>
        /// <param name="sortByReleaseDate">Sort by release date flag.</param>
        /// <param name="descending">Sort by descending flag.</param>
        /// <returns>A list of all the movies.</returns>
        public Task<List<Movie>> GetAllMoviesAsync(
            int pageNumber,
            int pageSize,
            string? genre,
            string? actor,
            bool sortByTitle,
            bool sortByReleaseDate,
            bool descending);

        /// <summary>
        /// Search for a movie by title asynchronously.
        /// </summary>
        /// <param name="title">The title of the movie to search for.</param>
        /// <param name="searchLimit">Limit the number of search results.</param>
        /// <param name="genre">The genre to filter on, null to ignore.</param>
        /// <returns>A list of movies that match the search.</returns>
        public Task<List<Movie>> SearchMovieByTitleAsync(string title, int searchLimit, string? genre);
    }
}
