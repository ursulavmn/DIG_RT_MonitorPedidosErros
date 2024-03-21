using DIG_RT_MonitorPedidosErros.Models.Entities;

namespace DIG_RT_MonitorPedidosErros.Services.Interfaces
{ 
    public interface IOrderService
    {
        Task<IEnumerable<int>> GetErrosPedidoAsync(int idOrder);
        Task<ErrosPedidosEntities> GetErrosPedidosListAsync();

    }
}
