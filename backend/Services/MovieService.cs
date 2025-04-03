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
            string? actor,
            string? orderBy,
            bool orderByDescending,
            int pageNumber,
            int pageSize)
        {
            var query = dbContext.Movies
                .AsNoTracking()
                .Include(movie => movie.Genres)
                .Where(movie =>
                    (title == null || movie.Title == title)
                    && (genre == null || movie.Genres.Any(genres => genres.Description == genre))
                    && (actor == null || movie.Actors.Any(actors => actors.Name == actor)))
                .Take(maxResults ?? int.MaxValue); // TODO: maxResults should be, at most, the count of the data.

            string orderByUpper = (orderBy ?? string.Empty).ToUpper();

            switch (orderByUpper)
            {
                case "TITLE":
                    query = orderByDescending ? query.OrderByDescending(movie => movie.Title) : query.OrderBy(movie => movie.Title); // TODO: Helper method?
                    break;
                case "DATE":
                    query = orderByDescending ? query.OrderByDescending(movie => movie.ReleaseDate) : query.OrderBy(movie => movie.ReleaseDate);
                    break;
                default:
                    query = orderByDescending ? query.OrderByDescending(movie => movie.Id) : query.OrderBy(movie => movie.Id);
                    break;
            }

            return await query
                .Skip((pageNumber - 1) * pageSize) // TODO: don't allow paging out the bounds of the data.
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
