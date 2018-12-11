using System;

namespace Actio.Common.Events
{
    public class ActivityCreated : IAuthenticationEvent
    {
        public Guid Id {get;}
        public Guid UserId { get;}    
        public string Category {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}

        protected ActivityCreated()
        {            
        }

        public ActivityCreated(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }

    }
}