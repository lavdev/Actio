namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email {get;set;}
        public string Name {get;}

        protected UserCreated(){
        }

        public UserCreated(string email, string name){
            Email =  email;
            Name = name;
        }
    }
}