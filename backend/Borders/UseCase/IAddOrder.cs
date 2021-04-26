using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.DTO.Restaurant.Response;
using GFT.Restaurant.Order.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.Borders.UseCase
{
    public interface IAddOrder
    {
        Task<AddOrderResponse> Execute(AddOrderRequest request);
    }
}
