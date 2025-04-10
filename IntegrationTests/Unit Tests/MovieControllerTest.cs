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
        public async void SearchWhenCalledWithNoParametersReturnsOkResult()
        {
            var options = new DbContextOptionsBuilder<DBContextTest>()
            .UseInMemoryDatabase(databaseName: "Movies")
            .Options;            

            using (var context = new DBContextTest(options))
            {
                context.Actors.Add(new Actor
                {
                    Id = 1,
                    Name = "Jamie Sandell"
                });
                context.Genres.Add(new Genre
                {
                    Id = 1,
                    Description = "Action"
                });
                context.Movies.Add(new Movie
                {
                    Id = 1,
                    Title = "Batman Begins",
                    Actors = {
                });
                context.SaveChanges();                
            }

            var actionResult = await controller.Search(null, null, null, null, null);            
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var movies = Assert.IsAssignableFrom<IList<Movie>>(okResult.Value).ToList();

            Assert.IsType<ActionResult<IList<Movie>>>(actionResult);
            Assert.NotEmpty(movies);
        }

        [Fact]
        public async void SearchWhenCalledWithInvalidTitleReturnsNotFoundResult()
        {
            var actionResult = await controller.Search("Jamie Sandell", null, null, null, null);
            var badResult = Assert.IsType<NotFoundResult>(actionResult.Result);

            Assert.NotNull(badResult);
            Assert.Equal(404, badResult.StatusCode);
        }
    }
}