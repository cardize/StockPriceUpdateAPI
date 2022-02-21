using Microsoft.EntityFrameworkCore;

namespace StockPriceUpdateAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
