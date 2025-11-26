using Domovenok.Application;
using Domovenok.Domain.Entities;
using Domovenok.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Persistence
{
    public class DomovenokDbContext : DbContext, IDomovenokDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPreferences> UsersPreferences { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Guarantee> Guarantees { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentLink> DocumentsLink { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ActivityLog> Logs { get; set; }

        public DomovenokDbContext(DbContextOptions<DomovenokDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserPreferencesConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new GuaranteeConfiguration());
            builder.ApplyConfiguration(new DocumentConfiguration());
            builder.ApplyConfiguration(new DocumentLinkConfiguration());
            builder.ApplyConfiguration(new SearchHistoryConfiguration());
            builder.ApplyConfiguration(new SessionConfiguration());
            builder.ApplyConfiguration(new ActivityLogConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
