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
        public async Task<List<Movie>> Search(
            string? title,
            int? maxResults,
            string? genre,
            int pageNumber,
            int pageSize)
        {
            var query = dbContext.Movies
                .AsNoTracking()
                .Include(movie => movie.Genres)
                .OrderBy(movie => movie.Title)
                .Where(movie =>
                    (title == null || movie.Title == title)
                    && (genre == null || movie.Genres.Any(genres => genres.Description == genre)))
                .Take(maxResults ?? int.MaxValue); // TODO: maxResults should be, at most, the count of the data.

            return await query
                .Skip((pageNumber - 1) * pageSize) // TODO: don't allow paging out the bounds of the data.
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
