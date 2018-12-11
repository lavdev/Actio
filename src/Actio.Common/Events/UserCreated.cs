namespace Actio.Common.Events
{
    /// <summary>
    /// User created control
    /// </summary>
    public class UserCreated : IEvent
    {
        #region Public properties
        public string Email {get;set;}
        public string Name {get;}
        #endregion

        #region Protected constructor
        protected UserCreated(){
        }
        #endregion

        #region Constructor
        /// <summary>
        /// User created information
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="name">User name</param>
        public UserCreated(string email, string name){
            Email =  email;
            Name = name;
        }
        #endregion
    }
}