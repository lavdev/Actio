using System;

namespace Actio.Common.Events
{
    public interface IAuthenticationEvent : IEvent
    {
         Guid UserId {get;}
    }
}