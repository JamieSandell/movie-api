namespace Backend.Repositories
{
    using Backend.Data;
    using Backend.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The movie service.
    /// </summary>
    public class MovieServices : IMovieServices
    {
        /// <inheritdoc/>
        Task<List<Movie>> IMovieServices.GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
