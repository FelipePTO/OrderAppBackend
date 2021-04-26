using GFT.Restaurant.Order.Borders.DTO.Restaurant.Request;
using GFT.Restaurant.Order.Borders.UseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IGetListOrders _getListOrders;
        private readonly IAddOrder _addOrder;

        public RestaurantController(ILogger<RestaurantController> logger, IGetListOrders getListOrders, IAddOrder addOrder)
        {
            _logger = logger;
            _getListOrders = getListOrders;
            _addOrder = addOrder;
        }

        [HttpGet]
        public async Task<IActionResult> ListOrders()
        {
            return Ok(await _getListOrders.Execute());
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
        {
            try
            {
                return Ok(await _addOrder.Execute(request));
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
