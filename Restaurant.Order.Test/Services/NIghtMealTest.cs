using FluentAssertions;
using GFT.Restaurant.Order.Services.MealList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Order.Test.Services
{
    public class NIghtMealTest
    {

        [Theory]
        [InlineData("night, 1, 2, 3, 4", "steak, potato, wine, cake, ")]
        [InlineData("night, 1, 2, 2, 4", "steak, potato(x2), cake, ")]
        [InlineData("night, 1, 2, 3, 5", "steak, potato, wine, error, ")]
        [InlineData("night, 1, 1, 2, 3, 5", "steak, error, ")]
        public void ToMealList_ReturnOutpulit_WhenValidInput(string input, string result)
        {
            //Arrange
            var service = new NightMeal();
            //Act
            var response = service.ToMealList(input);
            //Assert
            response.Should().Be(result);
        }
    }
}
