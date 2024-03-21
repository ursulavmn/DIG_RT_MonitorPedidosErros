using DIG_RT_MonitorPedidosErros.Services.Interfaces;
using Quartz;

namespace DIG_RT_MonitorPedidosErros.HostedService
{

    public class ProcessHostedServicesvice : IJob
    {
        private readonly ILogger<ProcessHostedServicesvice> _logger;
        private readonly IRefreshStateService _refreshState;

        public ProcessHostedServicesvice(ILogger<ProcessHostedServicesvice> logger, IRefreshStateService atualizaStatus)
        {
            _logger = logger;
            _refreshState = atualizaStatus;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation($"Iniciando... {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");

                _refreshState.ProcessRefreshState();

                _logger.LogInformation($"Finalizando... {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro na aplicacao. => Erro: {e.Message}");
            }


            return Task.FromResult(context.CancellationToken);
        }
    }
}