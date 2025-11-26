using Domovenok.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Domain.Entities
{
    public class UserPreferences
    {
        public Guid UserId { get; set; }

        public ThemeType Theme { get; set; }
        public LanguageType Language { get; set; }
        public bool NotificationsEnabled { get; set; }
        public bool EmailNotifications { get; set; }
        public bool PushNotifications { get; set; }

        public int ReminderDaysDefault { get; set; }

        //1:1
        public User User { get; set; }
    }
}
