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
    public class MorningMealTest
    {

        [Theory]
        [InlineData("morning, 1, 2, 3", "eggs, toast, coffee, ")]
        [InlineData("morning, 2, 1, 3", "eggs, toast, coffee, ")]
        [InlineData("morning, 1, 2, 3, 4", "eggs, toast, coffee, error, ")]
        [InlineData("morning, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3), ")]
        public void ToMealList_ReturnOutpulit_WhenValidInput(string input, string result)
        {
            //Arrange
            var service = new MorningMeal();
            //Act
            var response = service.ToMealList(input);
            //Assert
            response.Should().Be(result);
        }
    }
}
