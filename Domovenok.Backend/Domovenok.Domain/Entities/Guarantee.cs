using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class Guarantee
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string Provider { get; set; }
        public string? Type { get; set; }
        public DateTime WarrantyStart { get; set; }
        public DateTime WarrantyEnd { get; set; }
        public string? FileUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //1:1
        public Item Item { get; set; }
    }
}
