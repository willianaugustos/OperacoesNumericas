using BenchmarkDotNet.Attributes;
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
        [Params(1, 11, 30, 641, 1510, 1511)]
        public int numero { get; set; }
        public int[] numerosDivisores { get; private set; }

        public int[] primosDivisores { get; private set; }


        public OperacoesNumericas()
        {

        }


        public ResultadoDeAnaliseNumerica AnalisaNumero(int numero)
        {
            this.numero = numero;
            ObterDivisoresPadrao();

            //AnalisaDivisores();
            return new ResultadoDeAnaliseNumerica(numerosDivisores, primosDivisores);
        }


        [Benchmark]
        public void ObterDivisoresBruto()
        {
            //Esse método foi criado como referência para o benchmark
            //mas não é usado como o "oficial" da solução, porquê ele não está otimizado.

            if (numero <= 0)
            {
                numerosDivisores = Array.Empty<int>();
                primosDivisores = Array.Empty<int>();
                return;
            }

            var divisores = new List<int>();
            var primos = new List<int>();

            for (int auxiliar = 2; auxiliar <= numero; auxiliar++)
            {
                if (numero % auxiliar == 0)
                {
                    divisores.Add(auxiliar);

                    if (AnalisaPrimoBruto(auxiliar))
                        primos.Add(auxiliar);
                }
            }

            //não precisa reordenar pois foram incluídos em ordem crescente
            numerosDivisores = divisores.ToArray();
            primosDivisores = primos.ToArray();
        }


        [Benchmark]
        public void ObterDivisoresPadrao()
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
            var divisores = new HashSet<int>() { 1 };

            //1 não é primo, então a lista não começa com ele
            //eu descobri isso aqui: https://www.laboratoriosustentaveldematematica.com/2019/04/por-que-1-nao-e-primo-por-prof-daniela.html
            var primos = new HashSet<int>() { };

            //todo número é divisível por ele mesmo
            //se ele é 1, já foi adicionado à lista
            if (numero != 1)
            {
                divisores.Add(numero);

                //se é primo, inclui na lista
                if (AnalisaPrimoPadrao(numero))
                    primos.Add(numero);
            }

            //define o maior número "possivelmente" divisor como sendo a metade...
            //nenhum número pode ser divisível por um número maior que sua metade (com exceção dele próprio)
            //exemplo: 30 não tem divisores maior que 15, exceto o próprio 30.
            //mais à frente o algoritmo vai reduzir esse limite ainda mais, conforme for descobrindo novos divisores
            int limite = numero / 2;
            int auxiliar = 2;
            while (auxiliar < limite)
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
                    if (AnalisaPrimoPadrao(auxiliar))
                        primos.Add(auxiliar);

                    if (AnalisaPrimoPadrao(resultado))
                        primos.Add(resultado);

                    //estreita o limite máximo de tentativas
                    limite = resultado;
                }
                auxiliar++;
            }

            //reordena e atribui a lista de divisores e primos a retornar
            numerosDivisores = divisores.OrderBy(n => n).ToArray();
            primosDivisores = primos.OrderBy(n => n).ToArray();
        }

        private bool AnalisaPrimoPadrao(int numero)
        {
            //se um número não tiver divisores menores ou iguais a sua raiz quadrada,
            //então ele é primo.
            //descobri isso pesquisando aqui: https://www.cin.ufpe.br/~gdcc/matdis/aulas/divisibilidade (slide 12)

            //o maior divisor de um número primo é a sua raiz quadrada arredondado para inteiro.
            int limite = Convert.ToInt32(Math.Sqrt(numero));
            for (int auxiliar = 2; auxiliar <= limite; auxiliar++)
            {
                //se encontrou algum divisor, já pode parar de procurar, pois não é primo.
                if (numero % auxiliar == 0)
                    return false;
            }
            return true; //se chegar aqui, então é primo
        }


        private bool AnalisaPrimoBruto(int numero)
        {
            //esse não é o algoritmo da solução
            //criei ele apenas para fins comparativos com o método "padrão"

            for (int auxiliar = 2; auxiliar <= numero; auxiliar++)
            {
                if (numero % auxiliar == 0)
                    return false;
            }
            return true; //se chegar aqui, então é primo
        }
    }
}
