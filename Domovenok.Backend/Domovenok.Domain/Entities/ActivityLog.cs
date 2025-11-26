using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class ActivityLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        //1:M
        public User User { get; set; }
    }
}
