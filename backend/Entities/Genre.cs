// <copyright file="Genre.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The Genre class.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Gets or sets the unique id of the Movie_Genre.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the genre, e.g. Horror.
        /// </summary>
        required public string Description { get; set; }
    }
}
