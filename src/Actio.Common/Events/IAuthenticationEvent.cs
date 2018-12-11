using System;

namespace Actio.Common.Events
{
    /// <summary>
    /// Authentication interface
    /// </summary>
    public interface IAuthenticationEvent : IEvent
    {
         Guid UserId {get;}
    }
}