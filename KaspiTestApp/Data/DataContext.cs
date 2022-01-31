using Microsoft.EntityFrameworkCore;

namespace KaspiTestApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Payment> Payments { get; set; }
    }
}
