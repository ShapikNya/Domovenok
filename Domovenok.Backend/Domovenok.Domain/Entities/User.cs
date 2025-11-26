using Domovenok.Domain.Enums;

namespace Domovenok.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RoleType Role { get; set; }

        public string Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? UpdatedAt { get; set; }


        // 1:1
        public UserPreferences UserPreferences { get; set; }

        // 1:M
        public List<Item> Items { get; set; } = new();
        public List<Document> Documents { get; set; } = new();
        public List<SearchHistory> SearchHistory { get; set; } = new();
        public List<Session> Sessions { get; set; } = new();
        public List<ActivityLog> ActivityLogs { get; set; } = new();
        public List<Event> Events { get; set; } = new();
        public List<Notification> Notifications { get; set; } = new();

    }
}
