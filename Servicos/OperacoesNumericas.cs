using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class OperacoesNumericas : IOperacoesNumericas
    {
        public OperacoesNumericas()
        {

        }


        public ResultadoDeAnaliseNumerica AnalisaNumero(int numero)
        {
            int[] numerosDivisores;
            int[] primosDivisores;

            ObterDivisores(numero, out numerosDivisores, out primosDivisores);

            //AnalisaDivisores();
            return new ResultadoDeAnaliseNumerica(numerosDivisores, primosDivisores);
        }

        private void ObterDivisores(int numero, out int[] numerosDivisores, out int[] primosDivisores)
        {
            //número zero não tem divisores
            //embora os números negativos possuam divisores e possam ser primos, não estou tratando negativos nesse contexto
            if (numero <= 0)
            {
                numerosDivisores = Array.Empty<int>();
                primosDivisores = Array.Empty<int>();
                return;
            }

            //todo número natural é divisível por 1
            var divisores = new List<int>() { 1 };

            //1 não é primo, então a lista não começa com ele
            //eu descobri isso aqui: https://www.laboratoriosustentaveldematematica.com/2019/04/por-que-1-nao-e-primo-por-prof-daniela.html
            var primos = new List<int>() { };

            //todo número é divisível por ele mesmo
            //se ele é 1, já foi adicionado à lista
            if (numero != 1)
            {
                divisores.Add(numero);

                //se é primo, inclui na lista
                if (AnalisaPrimo(numero))
                    primos.Add(numero);
            }

            //define o maior número "possivelmente" divisor como sendo a metade...
            //nenhum número pode ser divisível por um número maior que sua metade (com exceção dele próprio)
            //exemplo: 30 não tem divisores maior que 15, exceto o próprio 30.
            int limite = numero / 2;

            for (int auxiliar = 2; auxiliar < limite; auxiliar++)
            {
                //se o auxiliar já está nalista, não precisa analisar
                if (!divisores.Contains(auxiliar))
                {
                    if (numero % auxiliar == 0) //se resto da divisão é zero, então é divisor
                    {
                        //adiciona o divisor na lista
                        divisores.Add(auxiliar);

                        //adiciona na lista também o resultado da divisão
                        //exemplo: se 30 é divisível por 2, ele também é por 15 (resultado da divisão) 
                        var resultado = numero / auxiliar;
                        if (resultado != auxiliar) //não adiciona se for o próprio número. Exemplo: 9/3=3 (3 é divisor e também resultado)
                        {
                            divisores.Add(numero / auxiliar);
                        }

                        //analisa se os números são primos e adiciona à lista
                        if (AnalisaPrimo(auxiliar))
                            primos.Add(auxiliar);

                        if (AnalisaPrimo(resultado))
                            primos.Add(resultado);
                    }
                }
            }

            //reordena e atribui a lista de divisores e primos a retornar
            numerosDivisores = divisores.OrderBy(n=>n).ToArray();
            primosDivisores = primos.OrderBy(n=>n).ToArray();
        }

        private bool AnalisaPrimo(int numero)
        {
            //se um número não tiver divisores menores ou iguais a sua raiz quadrada,
            //então ele é primo.
            //descobri isso pesquisando aqui: https://www.cin.ufpe.br/~gdcc/matdis/aulas/divisibilidade (slide 12)

            //para evitar o uso de Math.Sqrt, eu troquei por analisar o quadrado da var. auxiliar
            //Outra forma seria.. auxiliar < Math.Sqrt(numero)
            for (int auxiliar = 2; auxiliar*auxiliar <= numero; auxiliar++)
            {
                if (numero % auxiliar == 0)
                return false;
            }
            return true; //se chegar aqu é primo
        }
    }
}
