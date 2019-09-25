using System;
using System.Runtime.InteropServices.ComTypes;
using Comment;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace Fairhr.Service.C.Controllers
{
    [Route("sub")]
    public class SubController : ControllerBase
    {
        private readonly AliPayInfoContext _payInfoContext;

        public SubController(AliPayInfoContext payInfoContext)
        {
            _payInfoContext = payInfoContext;
        }

        [CapSubscribe("order_route_key",Group = "service.c")]
        public void GetOrderInfo(OrderDto order)
        {
            if (order != null)
            {
                PayInfo info=new PayInfo();
                info.OrderId = order.OrderId;
                info.Id = Guid.NewGuid().ToString("N");
                info.Money = order.Money;
                info.stauts = 0;
                info.CrateTime = DateTime.Now;
                _payInfoContext.PayInfo.Add(info);
                _payInfoContext.SaveChanges();
            }
        }
    }
}