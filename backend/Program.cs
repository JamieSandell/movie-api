// <copyright file="Program.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend
{
    using Backend.Data;
    using Backend.Services;

    /// <summary>
    /// The Program and main entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Arguments passed in at program startup.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddDbContext<DBContextClass>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment()) not recommended to comment out, but just for demo purposes.
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
