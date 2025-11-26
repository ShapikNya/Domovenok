using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class SearchHistory
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Query { get; set; }

        //1:M
        public User User { get; set; }

    }
}
