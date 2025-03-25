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
        /// Gets the unique id of the movie in the DB.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; }

        /// <summary>
        /// Gets the movie's release date.
        /// </summary>
        public DateOnly ReleaseDate { get; }

        /// <summary>
        /// Gets the movie's title.
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// Gets the movie's overview.
        /// </summary>
        public string? Overview { get; }

        /// <summary>
        /// Gets the movie's popularity.
        /// </summary>
        public float Popularity { get; }

        /// <summary>
        /// Gets the movie's vote count.
        /// </summary>
        public short VoteCount { get; }

        /// <summary>
        /// Gets the movie's vote average.
        /// </summary>
        public float VoteAverage { get; }

        /// <summary>
        /// Gets the movie's original language.
        /// </summary>
        public string? OriginalLanguage { get; }

        /// <summary>
        /// Gets the movie's genre.
        /// </summary>
        public string? Genre { get; }

        /// <summary>
        /// Gets the movie's poster URL.
        /// </summary>
        public string? PosterURL { get; }
    }
}
