using GFT.Restaurant.Order.Borders.Entities;
using GFT.Restaurant.Order.Borders.Repositories;
using GFT.Restaurant.Order.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantContext _restaurant;

        public RestaurantRepository(RestaurantContext restaurant)
        {
            _restaurant = restaurant;
        }

        public OrderEntity AddOrder(OrderEntity order)
        {
            _restaurant.orderhistory.Add(order);
            _restaurant.SaveChanges();
            return order;
        }

        public async Task<List<OrderEntity>> GetOrderHistory()
        {
            return await _restaurant.orderhistory.ToListAsync();
        }
    }
}
