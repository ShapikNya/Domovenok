using Domovenok.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsRecurring { get; set; }
        public string? RecurrenceFrequency { get; set; }
        public int? RecurrenceInterval { get; set; }
        public StatusType Status { get; set; }
        public int? ReminderDaysBefore { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        //1:M
        public User User { get; set; }
        public Item? Item { get; set; }
    }
}
