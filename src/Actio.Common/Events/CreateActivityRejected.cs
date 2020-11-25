using System;

namespace Actio.Common.Events
{
   public class CreateActivityRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Category { get; }
        public string Name { get; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateActivityRejected()
        {
            
        }

        public CreateActivityRejected(Guid id, Guid userId, string category, string name, string reason, string code)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Reason = reason;
            Code = code;
        }
    }
}
