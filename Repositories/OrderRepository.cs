using Dapper;
using DIG_RT_MonitorPedidosErros.Models.Entities;
using DIG_RT_MonitorPedidosErros.Repositories.Script;
using DIG_RT_MonitorPedidosErros.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DIG_RT_MonitorPedidosErros.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ILogger<OrderRepository> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<int>> GetErrosPedidoAsync(int idOrder)
        {
            try
            {
                using (var conn = new SqlConnection(EnvironmentVariable.GetConnectionDataBase()))
                {
                    var parametro = new { OrderId = idOrder };
                    var errors = await conn.QueryAsync<int>(OrderScripts.SelectPedidosErros, parametro);
                    return errors;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao consultar erros do pedido. => Erro: {e.Message}");
                return null;
            }
        }

        public Task<IEnumerable<int>> GetErrosPedidoAsync(string orderNumberId)
        {
            throw new NotImplementedException();
        }

        public async Task<ErrosPedidosEntities> GetErrosPedidosListAsync()
        {
            try
            {
                using (var conn = new SqlConnection(EnvironmentVariable.GetConnectionDataBase()))
                {
                    // Execute your query to get errors list
                    // Update this as per your actual implementation
                    var errorsList = await conn.QueryAsync<ErrosPedidosEntities>("Your SQL query here");

                    return errorsList.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar lista de erros de pedidos. => Erro: {e.Message}");
                return null;
            }
        }

        
    }
}
