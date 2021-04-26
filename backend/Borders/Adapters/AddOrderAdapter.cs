using GFT.Restaurant.Order.Borders.Adapters.Interface;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Response;
using GFT.Restaurant.Order.Borders.Entities;

namespace GFT.Restaurant.Order.Borders.Adapters
{
    public class AddOrderAdapter : IAddOrderAdapter
    {
        public OrderEntity ToEntity(string request, string input)
        {
            return new OrderEntity()
            {
                dish = request.Substring(0, request.Length - 2),
                input =  input
            };
        }

        public AddOrderResponse ToResponse(OrderEntity orderAdd)
        {
            return new AddOrderResponse()
            {
                input = orderAdd.input,
                dish = orderAdd.dish
            };
        }
    }
}
