using FluentAssertions;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.Entities;
using Restaurant.Order.Test.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Order.Test.DTO
{
    public class OrderEntityTest
    {

        [Fact]
        public void OrderEntity_WhenInputValid()
        {
            //Arrange
            var builder = new OrderEntityBuilder().WithId().Build();
            var request = new OrderEntity();
            //Act
            request.dish = builder.dish;
            request.input = builder.input;

            request.id = builder.id;
            //Assert
            request.Should().Equals(builder);
        }
    }
}
