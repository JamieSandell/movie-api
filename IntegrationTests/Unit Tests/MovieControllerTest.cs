namespace Backend.Tests.UnitTests
{
    using Backend.Controllers;
    using Backend.Data;
    using Backend.Entities;
    using Backend.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class MovieControllerTest
    {
        [Fact]
        public async Task SearchWhenCalledWithNoParametersReturnsOkResult()
        {
            // Arrange
            DbContextOptions<DBContextClass> options = new DbContextOptionsBuilder<DBContextClass>()
            .UseInMemoryDatabase(databaseName: "Movies")
            .Options;

            DBContextClass context = new(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Movies.AddRange(
                new Movie
                {
                    Id = 1,
                    Title = "The Batman",
                },
                new Movie
                {
                    Id = 2,
                    Title = "Superman",
                }
            );

            context.SaveChanges();

            MovieService movieService = new(context);
            MovieController movieController = new(movieService);

            // Act
            var actionResult = await movieController.Search(null, null, null, null, null);            
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var movies = Assert.IsAssignableFrom<IList<Movie>>(okResult.Value).ToList();

            // Assert
            Assert.IsType<ActionResult<IList<Movie>>>(actionResult);
            Assert.NotEmpty(movies);
        }

        [Fact]
        public async Task SearchWhenCalledWithInvalidTitleReturnsNotFoundResult()
        {
            // Arrange
            DbContextOptions<DBContextClass> options = new DbContextOptionsBuilder<DBContextClass>()
            .UseInMemoryDatabase(databaseName: "Movies")
            .Options;

            DBContextClass context = new(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Movies.AddRange(
                new Movie
                {
                    Id = 1,
                    Title = "The Batman",
                },
                new Movie
                {
                    Id = 2,
                    Title = "Superman",
                }
            );

            context.SaveChanges();

            MovieService movieService = new(context);
            MovieController movieController = new(movieService);

            // Act
            var actionResult = await movieController.Search("Jamie Sandell", null, null, null, null);
            var badResult = Assert.IsType<NotFoundResult>(actionResult.Result);

            // Assert
            Assert.NotNull(badResult);
            Assert.Equal(404, badResult.StatusCode);
        }

        [Fact]
        public async Task SearchWhenCalledWithValidTitleReturnsOkResult()
        {
            // Arrange
            DbContextOptions<DBContextClass> options = new DbContextOptionsBuilder<DBContextClass>()
            .UseInMemoryDatabase(databaseName: "Movies")
            .Options;

            DBContextClass context = new(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Movies.AddRange(
                new Movie
                {
                    Id = 1,
                    Title = "The Batman",
                },
                new Movie
                {
                    Id = 2,
                    Title = "Superman",
                }
            );

            context.SaveChanges();

            MovieService movieService = new(context);
            MovieController movieController = new(movieService);

            // Act
            var actionResult = await movieController.Search("The Batman", null, null, null, null);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var movies = Assert.IsAssignableFrom<IList<Movie>>(okResult.Value).ToList();

            // Assert
            Assert.IsType<ActionResult<IList<Movie>>>(actionResult);
            Assert.NotEmpty(movies);
        }
    }
}