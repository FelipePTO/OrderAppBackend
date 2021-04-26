using GFT.Restaurant.Order.Borders.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.Borders.Repositories
{
    public interface IRestaurantRepository
    {
        OrderEntity AddOrder(OrderEntity order);
        Task<List<OrderEntity>> GetOrderHistory();
    }
}
