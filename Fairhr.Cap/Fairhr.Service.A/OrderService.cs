using System.Threading.Tasks;
using Comment;
using DotNetCore.CAP;

namespace Fairhr.Service.A
{
    public class OrderService : IOrderService
    {
        private readonly OrderInfoContext _dbContext;
        private readonly ICapPublisher _publisher;

        public OrderService(OrderInfoContext dbContext, ICapPublisher capPublisher)
        {
            _dbContext = dbContext;
            _publisher = capPublisher;
        }

        public async Task<bool> CreateOrder(OrderInfo order)
        {
            using (var tran = _dbContext.Database.BeginTransaction())
            {
                OrderDto dto = new OrderDto();
                dto.OrderId = order.Id;
                dto.Money = order.Money;
                _dbContext.OrderInfo.Add(order);
                await _dbContext.SaveChangesAsync();
                await _publisher.PublishAsync("order_route_key", dto);
                tran.Commit();
            }

            return true;
        }
    }
}