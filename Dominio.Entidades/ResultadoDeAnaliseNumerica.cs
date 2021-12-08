using System;

namespace Dominio.Entidades
{
    public class ResultadoDeAnaliseNumerica
    {
        /// <summary>
        /// Lista dos números primos que são divisores do número analisado
        /// </summary>
        public int[] DivisoresPrimos { get; set; }

        /// <summary>
        /// Contém a lista de todos os divisores de do número analisado
        /// </summary>
        public int[] NumerosDivisores { get; set; }

        public ResultadoDeAnaliseNumerica(int[] Divisores, int[] DivisoresPrimos)
        {
            this.DivisoresPrimos = DivisoresPrimos;
            this.NumerosDivisores = Divisores;
        }
    }
}
