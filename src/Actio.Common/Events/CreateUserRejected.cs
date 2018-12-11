namespace Actio.Common.Events
{
    public class CreateUserRejected : IRectectedEvent
    {

        #region Public Properties
        public string Email {get;}
        public string Reason {get;}
        public string Code {get;}
        #endregion

        #region Protected Construcutor
        protected CreateUserRejected()
        {            
        }
        #endregion

        #region
        /// <summary>
        /// Create user "rejected" method
        /// It will be used for LOG stuff
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="reason">What reason (user or password  invalid  | user not exist...amd so on...)</param>
        /// <param name="code">Error code</param>
        public CreateUserRejected(string email, 
            string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
        #endregion
    }
}