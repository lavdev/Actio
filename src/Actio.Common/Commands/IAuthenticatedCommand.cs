using System;

namespace Actio.Common.Commands
{
    /// <summary>
    /// Interface to handler of exceptions
    /// </summary>
    public interface IAuthenticatedCommand : ICommand
    {
         Guid UserId {get;set;}
    }
}