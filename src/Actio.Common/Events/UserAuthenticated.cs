namespace Actio.Common.Events
{
    public class UserAuthenticated : IEvent
    {
        #region
        public string Email {get;}
        #endregion

        #region Protected Constructor
        protected UserAuthenticated()
        {
        }
        #endregion

        #region Construtor
        /// <summary>
        /// User authentication
        /// </summary>
        /// <param name="email"></param>
        public UserAuthenticated(string email){
            Email = email;
        }
        #endregion
    }
}