namespace Backend.Repositories
{
    using Backend.Entities;

    /// <summary>
    /// The movie repository.
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        /// <inheritdoc/>
        Task<List<Movie>> IMovieRepository.GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
