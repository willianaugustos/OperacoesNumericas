using Dominio.Interfaces;
using Dominio.Servicos;
using System;

namespace AppConsole.OperacoesNumericas
{



    class Program
    {
      


        static void Main(string[] args)
        {
         
            ExibeInformacoesIniciais();

            string strNumero;
            int numero;
            if (EntradaDeDados(out strNumero, out numero))
            {

                //obtem o serviço para realizar as operações:
                //poderia ter usado Injeção de Dependencia aqui, mas simplifiquei
                var servicoCache = new Infra.Servicos.GerenciadorDeCache();
                var servicoOperacoesNumericas = new Dominio.Servicos.OperacoesNumericas(servicoCache);

                var resultado = servicoOperacoesNumericas.AnalisaNumero(numero);

                ExibeResultados(strNumero, resultado);
            }
        }

        private static bool EntradaDeDados(out string strNumero, out int numero)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Entre com um número para análise: (utilize números inteiros positivos maiores que zero)");
            strNumero = Console.ReadLine();
            if (!Int32.TryParse(strNumero, out numero))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O número inserido não é válido.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        private static void ExibeInformacoesIniciais()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Desafio técnico .Net - Framework Digital" + Environment.NewLine);
            Console.WriteLine("Autor: William Augusto" + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O objetivo deste software é:");
            Console.WriteLine("1. Identificar os divisores de um número");
            Console.WriteLine("2. Dentre esses divisores, identificar quais são primos");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Atenção: O número 1 não é considerado primo.");
            Console.WriteLine();
        }

        private static void ExibeResultados(string strNumero, Dominio.Entidades.ResultadoDeAnaliseNumerica resultado)
        {
            Console.WriteLine();
            Console.WriteLine("Número de entrada: " + strNumero);

            Console.Write("Números divisores: ");
            foreach (var divisor in resultado.NumerosDivisores)
            {
                Console.Write(divisor.ToString());
                Console.Write(" ");
            }
            Console.WriteLine();

            Console.Write("Divisores primos: ");
            foreach (var divisor in resultado.DivisoresPrimos)
            {
                Console.Write(divisor.ToString());
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
