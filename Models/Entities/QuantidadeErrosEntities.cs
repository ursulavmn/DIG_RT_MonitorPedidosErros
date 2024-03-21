namespace DIG_RT_MonitorPedidosErros.Models.Entities
{
    public class ErrosData
    {
        
        public DateTime Date_created { get; set;}
        public int Id { get; set; }
        public int Processing_type_id { get; set; }
        public String OrderNumber { get; set; }

        public  string Message { get; set;}

        public int Error  { get; set;}

    }
}
