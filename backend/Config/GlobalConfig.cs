// <copyright file="GlobalConfig.cs" company="Jamie Sandell">
// Copyright (c) Jamie Sandell. All rights reserved.
// </copyright>

#nullable disable // Code smell, but used for migrations for the connection string.

namespace Backend.Config
{
    /// <summary>
    /// Global configuration.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Gets or sets Configuration.
        /// </summary>
        public static IConfiguration Configuration { get; set; }
    }
}
