using FluentAssertions;
using GFT.Restaurant.Order.Borders.Repositories;
using GFT.Restaurant.Order.UseCase;
using Moq;
using Restaurant.Order.Test.Builder;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Order.Test.UseCase
{
    public class GetListOrdersTest
    {
        private readonly Mock<IRestaurantRepository> _repository;
        private readonly GetListOrders _usecase;

        public GetListOrdersTest()
        {
            _repository = new Mock<IRestaurantRepository>();
            _usecase = new GetListOrders(_repository.Object);
        }

        [Fact]
        public async Task GetListOrders_ReturnSuccess_WhenReturnList()
        {
            var orderList = Enumerable.Range(default, 5).Select(x => new OrderEntityBuilder().Build()).ToList();
            _repository.Setup(d => d.GetOrderHistory()).ReturnsAsync(orderList);
            var response = await _usecase.Execute();
            response.Should().BeEquivalentTo(orderList);
        }
    }
}
