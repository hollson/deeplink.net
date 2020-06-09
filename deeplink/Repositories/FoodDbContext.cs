using Microsoft.EntityFrameworkCore;
using Deeplink.Entities;

namespace Deeplink.Repositories
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
           : base(options)
        {

        }

        public DbSet<FoodEntity> FoodItems { get; set; }

    }
}
