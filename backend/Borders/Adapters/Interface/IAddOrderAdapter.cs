using GFT.Restaurant.Order.Borders.DTO.Restaurant.Response;
using GFT.Restaurant.Order.Borders.Entities;

namespace GFT.Restaurant.Order.Borders.Adapters.Interface
{
    public interface IAddOrderAdapter
    {
        OrderEntity ToEntity(string request, string input);
        AddOrderResponse ToResponse(OrderEntity response);
    }
}
