using DIG_RT_MonitorPedidosErros.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DIG_RT_MonitorPedidosErros.Context
{
    public class AppDbContext : DbContext
    {
     public DbSet<ErrosPedidos> ErrosPedido { get; set; } 
    }
}
