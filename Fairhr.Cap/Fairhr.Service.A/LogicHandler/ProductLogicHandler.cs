using Comment;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fairhr.Service.A.LogicHandler
{
    public class ProductLogicHandler : IProductLogicHandler
    {
        private readonly ICapPublisher capPublisher;

        public ProductLogicHandler(ICapPublisher theCapPublisher)
        {
            capPublisher = theCapPublisher;
        }
        public async Task<List<ProductDto>> SendProductInfo()
        {
            // 具体业务
            List<ProductDto> infos = new List<ProductDto>();
            for (int i = 0; i < 5; i++)
            {
                ProductDto temp = new ProductDto();
                temp.Id = i;
                temp.Name = "产品名称" + i.ToString();
                temp.Price = "100";
                temp.Type = "节日福利";
                infos.Add(temp);
            }

            await capPublisher.PublishAsync("send.product", infos);
            return infos;
        }

        public void RollBack()
        {
            Console.WriteLine("rollback");
        }
    }
}
