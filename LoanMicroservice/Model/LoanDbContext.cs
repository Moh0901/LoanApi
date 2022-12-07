using Microsoft.EntityFrameworkCore;

namespace LoanMicroservice.Model
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }
        public DbSet<Loan> loan { get; set; }
    }
}
