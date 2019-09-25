using System;

namespace Fairhr.Service.C
{
    public class PayInfo
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 0 待支付 1 支付成功 2 支付失败
        /// </summary>
        public int stauts { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public string Money { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CrateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}