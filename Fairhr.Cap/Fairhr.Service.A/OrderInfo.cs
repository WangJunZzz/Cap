using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fairhr.Service.A
{
    public class OrderInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string Money { get; set; }    
        
        /// <summary>
        /// 0 待支付 1 支付成功 2 支付失败
        /// </summary>
        public int stauts { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CraeteTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
