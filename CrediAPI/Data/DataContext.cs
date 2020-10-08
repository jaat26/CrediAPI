using CrediAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrediAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
