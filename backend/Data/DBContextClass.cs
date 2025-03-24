namespace Backend.Data
{
    using Backend.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database connection to the data.
    /// </summary>
    /// <param name="configuration">Connection config.</param>
    public class DBContextClass(IConfiguration configuration) : DbContext
    {
        private readonly IConfiguration configuration = configuration;

        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Configure the database for this context.
        /// </summary>
        /// <param name="optionsBuilder">The config.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
