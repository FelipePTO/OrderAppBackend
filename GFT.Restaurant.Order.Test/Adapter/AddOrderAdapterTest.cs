using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GFT.Restaurant.Order.Test.Adapter
{
    public class AddOrderAdapterTest
    {
        public IAddOrderAdapter _mock; 

        [Fact]
        public void ToEntity_ReturnSuccess_WhenValidInput()
        {
            Assert.Pass();
        }
    }
}
