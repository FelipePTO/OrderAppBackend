using GFT.Restaurant.Order.Borders.Entities;
using GFT.Restaurant.Order.Borders.Repositories;
using GFT.Restaurant.Order.Borders.UseCase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.UseCase
{
    public class GetListOrders : IGetListOrders
    {
        private readonly IRestaurantRepository _repository;

        public GetListOrders(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderEntity>> Execute()
        {
            return await _repository.GetOrderHistory();
        }
    }
}
