using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Business.Shared.Abstract;
using CS.Business.Shared.Dto.Order;
using CS.Core.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS.WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<OrderController>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger) : base(logger)
        {
            _orderService = orderService;
        }
        
        [HttpPost]
        public void AddBasket([FromBody] IList<OrderDetailDto> orderDetailDtos)
        {
            _orderService.AddOrderDetails(orderDetailDtos);
        }

    }
}
