using Dominio.Interfaces;
using Dominio.Servicos;
using Infra.Interfaces;
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
        private readonly IGerenciadorDeCache _servicoCache;
        private readonly IOperacoesNumericas _servicoOperacoesNumericas;

        public OperacoesNumericasController(ILogger<OperacoesNumericasController> logger, IOperacoesNumericas servicoOperacoesNumericas)
        {
            _logger = logger;
            _servicoCache = new Infra.Servicos.GerenciadorDeCache();
            _servicoOperacoesNumericas = new OperacoesNumericas(_servicoCache);
        }

        [HttpGet]
        public ResultadoDivisoresDTO Get(int numero)
        {
            return new ResultadoDivisoresDTO(this._servicoOperacoesNumericas.AnalisaNumero(numero));
        }
    }
}
