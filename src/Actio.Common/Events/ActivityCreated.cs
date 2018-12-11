using System;

namespace Actio.Common.Events
{
    public class ActivityCreated : IAuthenticationEvent
    {
        #region Public Properties
        public Guid Id {get;}
        public Guid UserId { get;}    
        public string Category {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        #endregion

        #region Protected Constructor

        protected ActivityCreated()
        {
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Public class constructor
        /// </summary>
        /// <param name="id">Activity ID</param>
        /// <param name="userId">User ID</param>
        /// TODO: It can be enum, I will change later
        /// <param name="category">Activity Category</param>
        /// <param name="name">Activity name</param>
        /// <param name="description"></param>
        /// <param name="createdAt"></param>
        public ActivityCreated(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
        #endregion
    }
}