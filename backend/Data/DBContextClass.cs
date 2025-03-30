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
    /// <param name="configuration">Connection config.</param>
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
    public class DBContextClass(IConfiguration configuration) : DbContext
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
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
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DatabaseConnection"));
        }
    }
}
