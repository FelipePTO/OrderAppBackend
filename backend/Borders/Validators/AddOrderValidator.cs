using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.Validators.Interfaces;

namespace GFT.Restaurant.Order.Borders.Validators
{
    public class AddOrderValidator : IAddOrderValidator
    {
        public bool Validate(AddOrderRequest request)
        {
            

            return true;
        }

    }
}
