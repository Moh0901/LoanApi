using Microsoft.EntityFrameworkCore;

namespace UserMicroservice.Model
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> user { get; set; }
    }
}
