using cars_api.Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace cars_api.Data.Migrations
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

    }
}
