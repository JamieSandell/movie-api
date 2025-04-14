// <copyright file="DBContextClass.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Data
{
    using Backend.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database connection to the data.
    /// </summary>
    public class DBContextClass : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBContextClass"/> class.
        /// </summary>
        /// <param name="options">The config options.</param>
        public DBContextClass(DbContextOptions<DBContextClass> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the movies.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Gets or sets the moviesraw.
        /// </summary>
        public DbSet<MovieRaw> MoviesRaw { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// Configure the relationships.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>() // Unidirectional many-to-many
                .HasMany(e => e.Genres)
                .WithMany();

            modelBuilder.Entity<Movie>() // Unidirectional many-to-many
                .HasMany(e => e.Actors)
                .WithMany();
        }
    }
}
