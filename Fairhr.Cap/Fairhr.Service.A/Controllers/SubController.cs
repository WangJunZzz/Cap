using System;
using System.Runtime.InteropServices.ComTypes;
using Comment;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace Fairhr.Service.A.Controllers
{
    [Route("sub")]
    public class SubController : ControllerBase
    {
        private readonly OrderInfoContext _orderInfoContext;

        public SubController(OrderInfoContext orderInfoContext)
        {
            _orderInfoContext = orderInfoContext;
        }

        [CapSubscribe("pay")]
        public void GetOrderInfo(OrderDto order)
        {
            if (order != null)
            {
                OrderInfo orderInfo= _orderInfoContext.OrderInfo.Find(order.OrderId);
                orderInfo.stauts = order.Status;
                orderInfo.UpdateTime = DateTime.Now;
                _orderInfoContext.SaveChanges();
            }
        }
    }
}