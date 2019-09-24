using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace Fairhr.Service.A.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _publisher;
        private readonly IOrderService _orderService;

        public ValuesController(ICapPublisher capPublisher, IOrderService orderService)
        {
            _orderService = orderService;
            _publisher = capPublisher;
        }

        [HttpGet("order")]
        public async Task<IActionResult> CreateOrder()
        {
            OrderInfo order = new OrderInfo();
            order.Id = Guid.NewGuid().ToString("N");
            order.Name = "华为笔记本 - " + order.Id;
            order.Money = "99999";
            order.stauts = 0;
            order.CraeteTime = DateTime.Now;
            await _orderService.CreateOrder(order);
            return Ok(order.Name);
        }
    }
}