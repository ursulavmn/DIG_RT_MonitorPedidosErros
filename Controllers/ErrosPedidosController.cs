using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DIG_RT_MonitorPedidosErros.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DIG_RT_MonitorPedidosErros.Services.Interfaces;
using DIG_RT_MonitorPedidosErros.Services;

namespace dig_rt_monitorpedidoserros.controllers
{
    [Route("[controller]")]
    [ApiController]
    //controller --> serviço
    public class ErrosPedidosController : ControllerBase
    {

        private readonly IRefreshStateService refreshStateService;

        public ErrosPedidosController(IRefreshStateService refreshStateService)
        {
            this.refreshStateService = refreshStateService;
        }

        [HttpGet("Erros")]
        public IActionResult Get()
        {
            refreshStateService.ProcessRefreshState();

            return Ok();
        }

    }
}


