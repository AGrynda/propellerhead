using Microsoft.EntityFrameworkCore;

namespace propellerhead.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
