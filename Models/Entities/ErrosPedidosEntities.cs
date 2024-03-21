using System.ComponentModel.DataAnnotations.Schema;

namespace DIG_RT_MonitorPedidosErros.Models.Entities
{
   
    public class MonitorTypeEntities
    {
        public int Id { get; set; }
        public int Error { get; set; }
        public int Date_created { get; set; }
        public int Order_number { get; set; }

    }
}

