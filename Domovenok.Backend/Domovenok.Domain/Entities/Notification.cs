using Domovenok.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public EventType Type { get; set; }
        public bool IsRead { get; set; }
        public Guid? RelatedEntityId { get; set; }
        public EntityType? RelatedEntityType { get; set; }
        public DateTime CreatedAt { get; set; }

        //1:M
        public User User { get; set; }

    }
}
