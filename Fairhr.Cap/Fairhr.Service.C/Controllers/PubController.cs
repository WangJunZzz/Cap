using System;
using System.Linq;
using Comment;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace Fairhr.Service.C.Controllers
{
    [Route("pub")]
    public class PubController : ControllerBase
    {
        private readonly AliPayInfoContext _payInfoContext;
        private readonly ICapPublisher _publisher;

        public PubController(AliPayInfoContext payInfoContext, ICapPublisher publisher)
        {
            _payInfoContext = payInfoContext;
            _publisher = publisher;
        }

        [HttpGet("pay/{id}")]
        public void PubPay(string id)
        {
            using (var tran = _payInfoContext.Database.BeginTransaction())
            {
                PayInfo pay = _payInfoContext.PayInfo.Where(e=>e.OrderId==id).FirstOrDefault();
                pay.stauts = 1;
                pay.UpdateTime = DateTime.Now;
                _payInfoContext.SaveChanges();
                tran.Commit();
                OrderDto dto=new OrderDto();
                dto.OrderId = pay.OrderId;
                dto.Money = pay.Money;
                dto.Status = pay.stauts;
                _publisher.Publish("pay",dto);
            }
        }
    }
}