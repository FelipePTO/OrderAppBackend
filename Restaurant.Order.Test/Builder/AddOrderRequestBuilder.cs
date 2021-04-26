using Bogus;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Order.Test.Builder
{
    public class AddOrderRequestBuilder
    {
        public AddOrderRequest _instance;
        public Faker _faker = new Faker();
        public AddOrderRequestBuilder()
        {
            _instance = new AddOrderRequest()
            {
                listDishes = _faker.Random.String()
            };
        }

        public AddOrderRequest Build()
        {
            return _instance;
        }

    }
}
