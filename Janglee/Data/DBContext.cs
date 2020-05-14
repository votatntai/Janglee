using Microsoft.EntityFrameworkCore;

namespace Janglee.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Janglee.Models.DTO.User> User { get; set; }

        public DbSet<Janglee.Models.DTO.Product> Product { get; set; }
    }
}
