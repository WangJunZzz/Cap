using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Fairhr.Service.A.LogicHandler;
using Microsoft.AspNetCore.Mvc;

namespace Fairhr.Service.A.Controllers
{
    [Route("pub")]
    [ApiController]
    public class PubController : ControllerBase
    {
        private readonly ICapPublisher _publisher;
        private readonly IOrderService _orderService;
        private readonly IProductLogicHandler productLogicHandler;
        public PubController(ICapPublisher capPublisher, IOrderService orderService, IProductLogicHandler logicHandler)
        {
            _orderService = orderService;
            _publisher = capPublisher;
            productLogicHandler = logicHandler;
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

        [HttpGet("product")]
        public async Task<IActionResult> SendProduct()
        {
            return Ok(await productLogicHandler.SendProductInfo());
        }
    }
}