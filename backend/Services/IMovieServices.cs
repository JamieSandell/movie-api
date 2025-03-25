// <copyright file="IMovieRepository.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using Backend.Entities;

    /// <summary>
    /// Interface for the movie services.
    /// </summary>
    public interface IMovieServices
    {
        /// <summary>
        /// Get all the movies asynchronously.
        /// </summary>
        /// <returns>A list of all the movies</returns>
        Task<List<Movie>> GetAllMoviesAsync();
    }
}
