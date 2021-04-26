using Bogus;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Order.Test.Builder
{
    public class AddOrderResponseBuilder
    {
        public AddOrderResponse _instance;
        public Faker _faker = new Faker();
        public AddOrderResponseBuilder()
        {
            _instance = new AddOrderResponse()
            {
                dish = _faker.Random.String(),
                input = _faker.Random.String()
            };
        }

        public AddOrderResponse Build()
        {
            return _instance;
        }

    }
}
