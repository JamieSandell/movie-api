using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;

namespace Backend.Tests.Integration_Tests
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=MoviesTest;Integrated Security=False;User Id=sa;Password=MoviesAPI2025!;MultipleActiveResultSets=True;TrustServerCertificate=True"; // TODO: Read from Backend.appsettings.json

        private static readonly object _lock = new();
        private static bool _databaseInitialised;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialised)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.AddRange(
                            new Movie { Title = "The Batman" },
                            new Movie { Title = "Superman" });
                        context.SaveChanges();
                    }

                    _databaseInitialised = true;
                }
            }
        }

        public static DBContextClass CreateContext()
            => new(
                new DbContextOptionsBuilder<DBContextClass>()
                .UseSqlServer(ConnectionString)
                .Options);
    }
}
