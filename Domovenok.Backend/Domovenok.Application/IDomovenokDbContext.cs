using Domovenok.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application
{
    public interface IDomovenokDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserPreferences> UsersPreferences { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Guarantee> Guarantees { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<DocumentLink> DocumentsLink { get; set; }
        DbSet<SearchHistory> SearchHistory { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<ActivityLog> Logs { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
