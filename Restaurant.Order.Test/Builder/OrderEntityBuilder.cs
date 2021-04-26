using Bogus;
using GFT.Restaurant.Order.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Order.Test.Builder
{
    public class OrderEntityBuilder
    {
        public OrderEntity _instance;
        public Faker _faker = new Faker();
        public OrderEntityBuilder()
        {
            _instance = new OrderEntity()
            {
                dish = _faker.Random.String(),
                input = _faker.Random.String()
            };
        }

        public OrderEntityBuilder WithId()
        {
            _instance.id = _faker.Random.Int();
            return this;
        }

        public OrderEntity Build()
        {
            return _instance;
        }
    }
}
