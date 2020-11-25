namespace Actio.Common.Events
{
   public class UserCreated : IEvent
    {
        public string Email { get;  }
        public string Name { get;  }

        //serializers won't have any issues
        protected UserCreated()
        {
            
        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
