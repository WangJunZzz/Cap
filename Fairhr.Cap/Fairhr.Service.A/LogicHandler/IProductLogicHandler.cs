using Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fairhr.Service.A.LogicHandler
{
    public interface IProductLogicHandler
    {
        Task<List<ProductDto>> SendProductInfo();
    }
}
