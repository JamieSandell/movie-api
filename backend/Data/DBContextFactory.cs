// <copyright file="DBContextFactory.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Factory for DBContextClass, used to avoid having to use OnConfiguring for migrations.
    /// </summary>
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContextClass>
    {
        /// <inheritdoc/>
        public DBContextClass CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<DBContextClass>();
            string connectionString = configuration.GetConnectionString("LocalConnection") !;
            builder.UseSqlServer(connectionString);

            return new DBContextClass((DbContextOptions<DBContextClass>)builder.Options);
        }
    }
}
