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
        public async Task<List<Movie>> GetAllMoviesAsync(int pageNumber, int pageSize, string genre)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            if (genre == default)
            {
                return await dbContext.Movies.
                AsNoTracking()
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            }

            return await dbContext.Movies.
               AsNoTracking()
               .OrderBy(p => p.Id)
               .Where(p => p.Genre == genre)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<List<Movie>> SearchMovieByTitleAsync(string title, int searchLimit, string genre)
        {
            if (searchLimit < 1)
            {
                searchLimit = 1;
            }

            if (genre == default)
            {
                return await dbContext.Movies.
                AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => p.Title == title)
                .Take(searchLimit)
                .ToListAsync();
            }

            return await dbContext.Movies.
                AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => p.Title == title && p.Genre == genre)
                .Take(searchLimit)
                .ToListAsync();
        }
    }
}
