using GFT.Restaurant.Order.Borders.Adapters.Interface;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Response;
using GFT.Restaurant.Order.Borders.Entities;
using GFT.Restaurant.Order.Borders.Repositories;
using GFT.Restaurant.Order.Borders.Services;
using GFT.Restaurant.Order.Borders.UseCase;
using GFT.Restaurant.Order.Borders.Validators.Interfaces;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.UseCase
{
    public class AddOrder : IAddOrder
    {
        private readonly IRestaurantRepository _repository;
        private readonly IAddOrderAdapter _adapter;
        private readonly IMorningMeal _morningMeal;
        private readonly INightMeal _nightMeal;

        public AddOrder(IRestaurantRepository repository, IAddOrderAdapter adapter, IMorningMeal morningMeal, INightMeal nightMeal)
        {
            _repository = repository;
            _adapter = adapter;
            _morningMeal = morningMeal;
            _nightMeal = nightMeal;
        }

        public async Task<AddOrderResponse> Execute(AddOrderRequest request)
        {
            string dish = request.listDishes.Replace(" ", "").ToLowerInvariant();
            if (!(dish.StartsWith("morning,") || dish.StartsWith("night,")))
                throw new System.Exception("Is not a valid time of day");
            string outputList="";
            if (dish.StartsWith("morning,"))
            {
                outputList = _morningMeal.ToMealList(dish);
            }
            else if (dish.StartsWith("night,"))
            {
                outputList = _nightMeal.ToMealList(dish);
            }
            var entity = _repository.AddOrder(_adapter.ToEntity(outputList, request.listDishes));
            return _adapter.ToResponse(entity);
        }
    }
}
