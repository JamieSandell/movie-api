namespace Backend.Services
{
    using Backend.Data;
    using Backend.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The movie service.
    /// </summary>
    public class MovieService(DBContextClass dbContext) : IMovieService
    {
        /// <inheritdoc/>
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await dbContext.Movies.AsNoTracking().ToListAsync();
        }
    }
}
