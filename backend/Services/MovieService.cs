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
        public async Task<List<Movie>> GetAllMoviesAsync(
            int pageNumber,
            int pageSize,
            string? genre,
            string? actor,
            bool sortByTitle,
            bool sortByReleaseDate,
            bool descending)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            return await dbContext.Movies
                .FromSql($@"SELECT *
                            FROM Movies
                            WHERE
                                (
                                    {genre} IS NULL
                                    OR {genre} IN (SELECT LTRIM(VALUE) FROM STRING_SPLIT(Genre, ','))
                                )
                                AND
                                (
                                    {actor} IS NULL
                                    OR {actor} IN (SELECT LTRIM(VALUE) FROM STRING_SPLIT(Actors, ','))
                                )
                            ORDER BY
                                CASE
                                    --WHEN {sortByTitle} = 1 THEN TRY_CAST(Title AS NVARCHAR(MAX))
                                    WHEN {sortByReleaseDate} = 1 THEN TRY_CONVERT(DATETIME, ReleaseDate, 23)
                                ELSE Id
                                END
                            OFFSET ({pageNumber - 1}) * {pageSize} ROWS
                            FETCH NEXT {pageSize} ROWS ONLY")
                .AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<List<Movie>> SearchMovieByTitleAsync(string title, int searchLimit, string? genre)
        {
            if (searchLimit < 1)
            {
                searchLimit = 1;
            }

            if (genre == null)
            {
                return await dbContext.Movies.
                AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => p.Title == title)
                .Take(searchLimit)
                .ToListAsync();
            }

            return await dbContext.Movies
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => p.Title == title && p.Genres!.Any(g => g.Description == genre))
                .Take(searchLimit)
                .ToListAsync();
        }
    }
}
