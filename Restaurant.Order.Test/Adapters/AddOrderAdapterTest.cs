using FluentAssertions;
using GFT.Restaurant.Order.Borders.Adapters;
using GFT.Restaurant.Order.Borders.Adapters.Interface;
using Restaurant.Order.Test.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Order.Test.Adapters
{
    public class AddOrderAdapterTest
    {
        public IAddOrderAdapter _adapter;

        public AddOrderAdapterTest()
        {
            _adapter = new AddOrderAdapter();
        }

        [Fact]
        public void ToEntity_ReturnSuccess_WhenInputValid() {
            //Arrange
            var entity = new OrderEntityBuilder().Build();
            var dishes = entity.dish + ", ";
            //Act
            var entityResponse = _adapter.ToEntity(dishes, entity.input);
            //Assert
            entityResponse.Should().Equals(dishes);
        }

    }
}
