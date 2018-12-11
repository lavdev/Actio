using System;

namespace Actio.Common.Commands
{
    /// <summary>
    /// CreateActivity class
    /// It will store information from activity
    /// </summary>
    public class CreateActivity : IAuthenticatedCommand
    {
        /// <summary>
        /// Get/Set activity ID
        /// </summary>
        public Guid Id {get;set;}
        /// <summary>
        /// Get/Set user ID
        /// </summary>
        public Guid UserId { get; set;}
        /// <summary>
        /// Get/Set Category information
        /// </summary>
        public string Category {get;set;}
        /// <summary>
        /// Get/Set Activity name
        /// </summary>
        public string Name {get;set;}
        /// <summary>
        /// Get/Set Activity description (optional)
        /// </summary>
        public string Description {get;set;}
        /// <summary>
        /// Get/Set Activity created date information
        /// </summary>
        public DateTime CreatedAt {get;set;}
    }
}