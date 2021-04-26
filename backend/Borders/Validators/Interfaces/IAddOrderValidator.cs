using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;

namespace GFT.Restaurant.Order.Borders.Validators.Interfaces
{
    public interface IAddOrderValidator
    {
        bool Validate(AddOrderRequest request);
    }
}
