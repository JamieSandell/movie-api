// <copyright file="MovieService.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Data;
    using Backend.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The movie service.
    /// </summary>
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
    public class MovieService(DBContextClass dbContext) : IMovieService
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
    {
        /// <inheritdoc/>
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await dbContext.Movies.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<List<Movie>> SearchMovieByTitleAsync(string title, int searchLimit)
        {
            if (searchLimit < 1)
            {
                searchLimit = 1;
            }

            return await dbContext.Movies.
                Where(p => p.Title == title)
                .Take(searchLimit)
                .ToListAsync();
        }
    }
}
