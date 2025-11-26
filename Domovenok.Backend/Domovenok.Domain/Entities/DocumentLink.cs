using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class DocumentLink
    {
        public Guid DocumentId { get; set; }
        public Guid ItemId { get; set; }

        //M:M
        public Document Document { get; set; }
        public Item Item { get; set; }
    }
}
