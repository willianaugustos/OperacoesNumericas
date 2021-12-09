using System;

namespace WebApi
{
    public class ResultadoDivisoresDTO
    {
        int[] NumerosDivisores { get; set; }
        int[] PrimosDivisores { get; set; }

        public ResultadoDivisoresDTO(Dominio.Entidades.ResultadoDeAnaliseNumerica objDominio)
        {
            this.NumerosDivisores = objDominio.NumerosDivisores;
            this.PrimosDivisores = objDominio.DivisoresPrimos;
        }
    }
}
