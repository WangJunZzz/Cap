using Comment;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fairhr.Service.B.LogicHandler
{
    public class ProductLogicHandler : IProductLogicHandler, ICapSubscribe
    {
        private readonly WXPayInfoContext db;
        public ProductLogicHandler(WXPayInfoContext context)
        {
            db = context;
        }

        [CapSubscribe("send.product")]
        public object ReceiveProductInfo(object obj)
        {
            PayInfo payInfo = new PayInfo();
            payInfo.Id = Guid.NewGuid().ToString("N");
            payInfo.Money = "100";
            payInfo.OrderId += 1;
            payInfo.stauts = 1;
            payInfo.CrateTime = DateTime.Now;
            payInfo.UpdateTime = DateTime.Now;
            db.PayInfo.Add(payInfo);
            db.SaveChanges();
            // 具体业务
            throw new NullReferenceException("空指针异常.");
            //return obj;
        }

        public void RollBack()
        {
            Console.WriteLine("rollback");
        }
    }
}
