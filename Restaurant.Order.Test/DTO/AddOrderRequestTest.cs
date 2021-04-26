using FluentAssertions;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using Restaurant.Order.Test.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Order.Test.DTO
{
    public class AddOrderRequestTest
    {

        [Fact]
        public void AddOrderRequest_WhenInputValid()
        {
            //Arrange
            var builder = new AddOrderRequestBuilder().Build();
            var request = new AddOrderRequest();
            //Act
            request.listDishes = builder.listDishes;
            //Assert
            request.Should().Equals(builder);
        }
    }
}
