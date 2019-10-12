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
        [CapSubscribe("send.product")]
        public object ReceiveProductInfo(object obj)
        {
            // 具体业务

            return obj;
        }

        public void RollBack()
        {
            Console.WriteLine("rollback");
        }
    }
}
