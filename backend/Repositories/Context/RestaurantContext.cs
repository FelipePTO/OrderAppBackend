using GFT.Restaurant.Order.Borders.Entities;
using Microsoft.EntityFrameworkCore;

namespace GFT.Restaurant.Order.Repositories.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
          : base(options)
        { }
        public DbSet<OrderEntity> orderhistory { get; set; }
    }

}
