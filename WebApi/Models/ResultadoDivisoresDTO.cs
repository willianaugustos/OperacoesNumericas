using System;

namespace WebApi.Models
{
    public class ResultadoDivisoresDTO
    {
        public int[] NumerosDivisores { get; set; }
        public int[] PrimosDivisores { get; set; }

        public ResultadoDivisoresDTO(Dominio.Entidades.ResultadoDeAnaliseNumerica objDominio)
        {
            this.NumerosDivisores = objDominio.NumerosDivisores;
            this.PrimosDivisores = objDominio.DivisoresPrimos;
        }
    }
}
