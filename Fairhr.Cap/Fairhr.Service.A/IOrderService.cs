using System.Threading.Tasks;

namespace Fairhr.Service.A
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderInfo order);
    }
}