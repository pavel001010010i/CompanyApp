using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
