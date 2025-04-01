// <copyright file="Actor.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

namespace Backend.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The Genre class.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Gets or sets the unique id of the Actor.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name, e.g. Horror.
        /// </summary>
        required public string Name { get; set; }
    }
}
