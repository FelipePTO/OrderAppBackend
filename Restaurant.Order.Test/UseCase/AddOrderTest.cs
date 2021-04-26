using FluentAssertions;
using GFT.Restaurant.Order.Borders.Adapters;
using GFT.Restaurant.Order.Borders.Adapters.Interface;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Response;
using GFT.Restaurant.Order.Borders.Entities;
using GFT.Restaurant.Order.Borders.Repositories;
using GFT.Restaurant.Order.Borders.Services;
using GFT.Restaurant.Order.Services.MealList;
using GFT.Restaurant.Order.UseCase;
using Moq;
using Restaurant.Order.Test.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Order.Test.UseCase
{
    public class AddOrderTest
    {
        private readonly Mock<IRestaurantRepository> _repository;
        private readonly Mock<IAddOrderAdapter> _adapter;
        private readonly Mock<IMorningMeal> _morningMeal;
        private readonly Mock<INightMeal> _nightMeal;
        private readonly AddOrder _usecase;

        public AddOrderTest()
        {
            _repository = new Mock<IRestaurantRepository>();
            _adapter = new Mock<IAddOrderAdapter>();
            _morningMeal = new Mock<IMorningMeal>();
            _nightMeal = new Mock<INightMeal>();
            _usecase = new AddOrder(_repository.Object, _adapter.Object, _morningMeal.Object, _nightMeal.Object);
        }

        [Theory]
        [InlineData("night, 1, 2, 3, 4", "steak, potato, wine, cake")]
        [InlineData("night, 1, 2, 2, 4", "steak, potato(x2), cake")]
        [InlineData("night, 1, 2, 3, 5", "steak, potato, wine, error")]
        [InlineData("night, 1, 1, 2, 3, 5", "steak, error")]
        public async Task AddOrder_ReturnSucess_WhenInputValid(string input, string result)
        {
            var orderBuilder = new OrderEntity()
            {
                id=0,
                dish = result, 
                input = input
            };            
            var request = new AddOrderRequest()
            {
                listDishes=input
            };
            var responseAddOrder = new AddOrderResponse()
            {
                dish = result,
                input = input
            };

            var addOrderresponse = new AddOrderResponseBuilder().Build();
            string dish = input.Replace(" ", "").ToLowerInvariant(); ;
            _repository.Setup(d => d.AddOrder(orderBuilder)).Returns(orderBuilder);
            _adapter.Setup(d => d.ToEntity(input, input)).Returns(orderBuilder);
            _adapter.Setup(d => d.ToResponse(orderBuilder)).Returns(responseAddOrder);
            _morningMeal.Setup(d => d.ToMealList(dish)).Returns(input);
            _nightMeal.Setup(d => d.ToMealList(dish)).Returns(input);
            var response = await _usecase.Execute(request);
            response.Should().BeEquivalentTo(responseAddOrder);
        }

        [Fact]
        public async Task AddOrder_ReturnError_WhenInputInvalid()
        {
            var request = new AddOrderRequestBuilder().Build();
            string dish = null;
            var response = 
            Assert.ThrowsAsync<Exception>(async () => await _usecase.Execute(request));
        }



    }
}
