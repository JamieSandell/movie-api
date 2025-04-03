// <copyright file="Movie.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The movie class.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the unique id of the movie in the DB.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the movie's release date.
        /// </summary>
        public DateOnly? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the movie's title.
        /// </summary>
        public string? Title { get; set; } // TODO: index

        /// <summary>
        /// Gets or sets the movie's overview.
        /// </summary>
        public string? Overview { get; set; }

        /// <summary>
        /// Gets or sets the movie's popularity.
        /// </summary>
        public float? Popularity { get; set; }

        /// <summary>
        /// Gets or sets the movie's vote count.
        /// </summary>
        public short? VoteCount { get; set; }

        /// <summary>
        /// Gets or sets the movie's vote average.
        /// </summary>
        public float? VoteAverage { get; set; }

        /// <summary>
        /// Gets or sets the movie's original language.
        /// </summary>
        public string? OriginalLanguage { get; set; }

        /// <summary>
        /// Gets the navigation property for Genre.
        /// </summary>
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
        public List<Genre> Genres { get; } = [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly

        /// <summary>
        /// Gets or sets the movie's poster URL.
        /// </summary>
        public string? PosterURL { get; set; }

        /// <summary>
        /// Gets the navigation property for Actor.
        /// </summary>
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
        public List<Actor> Actors { get; } = [];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
    }
}
