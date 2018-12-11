namespace Actio.Common.Commands
{
    /// <summary>
    /// AuthenticatedUser class
    /// It will store the authenticated user
    /// </summary>
    public class AuthenticateUser : ICommand
    {
        /// <summary>
        /// Get/Set user email
        /// </summary>
        public string Email {get;set;}
        /// <summary>
        /// Get/Set user password
        /// </summary>
        public string Password {get;set;}
    }
}