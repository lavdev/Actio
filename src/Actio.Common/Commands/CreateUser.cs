namespace Actio.Common.Commands
{
    /// <summary>
    /// CreateUser Class
    /// It will store information of user that will be created
    /// </summary>
    public class CreateUser : ICommand
    {
        #region Public properties
        /// <summary>
        /// Get/Set User email
        /// </summary>
        public string Email {get;set;}
        /// <summary>
        /// Get/Set User password
        /// </summary>
        public string Password {get;set;}
        /// <summary>
        /// Get/Set User name
        /// </summary>
        public string Name {get;set;}
        #endregion
    }
}