using Dominio.Interfaces;
using Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacoesNumericasController : ControllerBase
    {
        private readonly ILogger<OperacoesNumericasController> _logger;
        private readonly IOperacoesNumericas _servicoOperacoesNumericas;

        public OperacoesNumericasController(ILogger<OperacoesNumericasController> logger, IOperacoesNumericas servicoOperacoesNumericas)
        {
            _logger = logger;
            //_servicoOperacoesNumericas = servicoOperacoesNumericas;
            _servicoOperacoesNumericas = new OperacoesNumericas();
        }
        [HttpGet]
        [Route("/api/info")]
        public string Info()
        {
            return Environment.GetEnvironmentVariable("RedisConnection");
        }

        [HttpGet]
        public ResultadoDivisoresDTO Get(int numero)
        {
            return new ResultadoDivisoresDTO(this._servicoOperacoesNumericas.AnalisaNumero(numero));
        }
    }
}
