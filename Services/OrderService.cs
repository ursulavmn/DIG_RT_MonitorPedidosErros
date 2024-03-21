using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DIG_RT_MonitorPedidosErros.Models.Entities;
using DIG_RT_MonitorPedidosErros.Repositories;
using DIG_RT_MonitorPedidosErros.Services.Interfaces;

namespace DIG_RT_MonitorPedidosErros.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public string Order { get; private set; }

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<ErrosPedidosEntities> GetErrosPedidosListAsync()
        {
            return _orderRepository.GetErrosPedidosListAsync();
        }

        public async Task<IEnumerable<int>> GetErrosPedidoAsync(int idOrder)
        {
           
            var orderNumberId = String.Join("", Regex.Split(Order, @"[^\d]"));
            var errors = await _orderRepository.GetErrosPedidoAsync(orderNumberId);
            return errors;
        }
    }
}
