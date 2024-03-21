namespace DIG_RT_MonitorPedidosErros.Util
{
    public class EnvironmentVariable
    {
        //Conexao
        private static readonly string APPLICATION_NAME = Environment.GetEnvironmentVariable("APPLICATION_NAME");
        private static readonly string DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
        private static readonly string DATABASE_USER = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string DATABASE_PASS = Environment.GetEnvironmentVariable("DATABASE_PASS");
        

        public static string GetConnectionDataBase()
        {
            return $"Application Name={APPLICATION_NAME}; Server={DATABASE_HOST}; "
                 + $"User Id={DATABASE_USER}; Password={DATABASE_PASS}; MultipleActiveResultSets=true; ";
                 
        }

        //Config
        public static readonly string QUARTZ_SCHEDULLE = Environment.GetEnvironmentVariable("QUARTZ_SCHEDULLE");

    }
}
