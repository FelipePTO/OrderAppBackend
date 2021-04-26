using GFT.Restaurant.Order.Borders.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.Borders.UseCase
{
    public interface IGetListOrders
    {
        Task<List<OrderEntity>> Execute(); 
    }
}
