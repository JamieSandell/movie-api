namespace Backend.Tests.Integration_Tests
{
    using Backend.Controllers;
    using Backend.Data;
    using Backend.Entities;
    using Backend.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class IntegrationTests(TestDatabaseFixture fixture) : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture = fixture;

        [Fact]
        public async Task SearchMovies()
        {
            using var context = TestDatabaseFixture.CreateContext();
        }
    }
}
