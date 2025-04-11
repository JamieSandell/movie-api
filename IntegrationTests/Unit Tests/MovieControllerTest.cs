namespace Backend.Tests.UnitTests
{
    using Backend.Controllers;
    using Backend.Data;
    using Backend.Entities;
    using Backend.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class MovieControllerTest
    {
        private readonly MovieController movieController;
        private readonly MovieService movieService;

        public MovieControllerTest()
        {
            var services = new ServiceCollection();
            // Using In-Memory database for testing
            services.AddDbContext<DBContextClass>(options =>
                options.UseInMemoryDatabase("MoviesTest"));
            services.AddScoped<IMovieService, MovieService>();

            var options = new DbContextOptionsBuilder<DBContextClass>()
            .UseInMemoryDatabase(databaseName: "Movies")
            .Options;

            var context = new DBContextClass(options);
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

            movieService = new MovieService(context);
            movieController = new MovieController(movieService);
        }

        [Fact]
        public async void SearchWhenCalledWithNoParametersReturnsOkResult()
        {
            var actionResult = await movieController.Search(null, null, null, null, null);            
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var movies = Assert.IsAssignableFrom<IList<Movie>>(okResult.Value).ToList();

            Assert.IsType<ActionResult<IList<Movie>>>(actionResult);
            Assert.NotEmpty(movies);
        }

        [Fact]
        public async void SearchWhenCalledWithInvalidTitleReturnsNotFoundResult()
        {
            var actionResult = await movieController.Search("Jamie Sandell", null, null, null, null);
            var badResult = Assert.IsType<NotFoundResult>(actionResult.Result);

            Assert.NotNull(badResult);
            Assert.Equal(404, badResult.StatusCode);
        }

        [Fact]
        public async void SearchWhenCalledWithValidTitleReturnsOkResult()
        {
            var actionResult = await movieController.Search("The Batman", null, null, null, null);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var movies = Assert.IsAssignableFrom<IList<Movie>>(okResult.Value).ToList();

            Assert.IsType<ActionResult<IList<Movie>>>(actionResult);
            Assert.NotEmpty(movies);
        }
    }
}