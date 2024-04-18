using Microsoft.EntityFrameworkCore;

namespace YandexRasp {
    public class RaspModelDbContext : DbContext {
        public DbSet<RaspDBModel> RaspDBTable { get; set; }

        public RaspModelDbContext(DbContextOptions options) : base(options) {
            
        }
    }
}