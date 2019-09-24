using System;
using System.Runtime.InteropServices.ComTypes;
using Comment;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace Fairhr.Service.B.Controllers
{
    [Route("sub")]
    public class SubController : ControllerBase
    {
        private readonly PayInfoContext _payInfoContext;

        public SubController(PayInfoContext payInfoContext)
        {
            _payInfoContext = payInfoContext;
        }

        [CapSubscribe("order_route_key")]
        public void GetOrderInfo(OrderDto order)
        {
            if (order != null)
            {
                PayInfo info=new PayInfo();
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