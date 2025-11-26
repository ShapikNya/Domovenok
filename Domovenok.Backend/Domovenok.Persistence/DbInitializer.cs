using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DomovenokDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
