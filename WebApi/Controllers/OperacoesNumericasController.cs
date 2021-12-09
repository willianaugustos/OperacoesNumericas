using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacoesNumericasController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OperacoesNumericasController> _logger;
        private readonly IOperacoesNumericas _servicoOperacoesNumericas;

        public OperacoesNumericasController(ILogger<OperacoesNumericasController> logger, IOperacoesNumericas servicoOperacoesNumericas)
        {
            _logger = logger;
            _servicoOperacoesNumericas = servicoOperacoesNumericas;
        }

        [HttpGet]
        public ResultadoDivisoresDTO Get(int numero)
        {
            return new ResultadoDivisoresDTO(this._servicoOperacoesNumericas.AnalisaNumero(numero));
        }
    }
}
