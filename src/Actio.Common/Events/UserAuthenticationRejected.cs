namespace Actio.Common.Events
{
   public class UserAuthenticationRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        protected UserAuthenticationRejected()
        {
            
        }

        public UserAuthenticationRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
