using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string? Type { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        public string? FileUrl { get; set; }
        public string? FileName { get; set; }
        public long? FileSize { get; set; }
        public string FileType { get; set; }

        public DateTime? ExpiryDate { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //1:M
        public User User { get; set; }

        //M:M
        public List<DocumentLink> Links { get; set; } = new();
    }
}
