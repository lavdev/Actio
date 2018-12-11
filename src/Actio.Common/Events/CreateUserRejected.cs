namespace Actio.Common.Events
{
    public class CreateUserRejected : IRectectedEvent
    {

        public string Email {get;}
        public string Reason {get;}
        public string Code {get;}

        protected CreateUserRejected()
        {            
        }

        public CreateUserRejected(string email, 
            string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}