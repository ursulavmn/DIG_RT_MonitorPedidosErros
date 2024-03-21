using System.Collections.Generic;
using System.Threading.Tasks;
using DIG_RT_MonitorPedidosErros.Models.Entities;

namespace DIG_RT_MonitorPedidosErros.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<int>> GetErrosPedidoAsync(int idOrder);
        Task<IEnumerable<int>> GetErrosPedidoAsync(string orderNumberId);
        Task<ErrosPedidosEntities> GetErrosPedidosListAsync();
       
    }
}
