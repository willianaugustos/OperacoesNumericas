using Dominio.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testes
{
    [TestClass]
    public class OperacoesNumericasTest
    {
        private OperacoesNumericas servOperacoesNumericas;

        [TestInitialize]
        public void InicializarServicos()
        {
            this.servOperacoesNumericas = new OperacoesNumericas();
        }

        [TestMethod]
        public void QuandoPassaNumeroZeroRetornaVazio()
        {
            //arrange
            var numero = 0;
            var numerosDivisoresEsperados = Array.Empty<int>();
            var divisoresPrimosEsperados = Array.Empty<int>();

            //act
            var resultado = servOperacoesNumericas.AnalisaNumero(numero);

            //assert
            Assert.AreEqual(resultado.NumerosDivisores, numerosDivisoresEsperados);
            Assert.AreEqual(resultado.NumerosDivisores, divisoresPrimosEsperados);
        }

        [TestMethod]
        public void QuandoAnalisaNumero10RetornaDivisoresCorretos()
        {
            //arrange
            var numero = 10;
            var numerosDivisoresEsperados = new int[] { 1, 2, 5, 10 };
            var divisoresPrimosEsperados = new int[] { 2, 5 };

            //act
            var resultado = servOperacoesNumericas.AnalisaNumero(numero);

            //assert
            CollectionAssert.AreEqual(resultado.NumerosDivisores, numerosDivisoresEsperados);
            CollectionAssert.AreEqual(resultado.DivisoresPrimos, divisoresPrimosEsperados);
        }

        [TestMethod]
        public void QuandoAnalisaNumero647RetornaDivisoresCorretos()
        {
            //arrange
            var numero = 647;
            var numerosDivisoresEsperados = new int[] { 1, 647};
            var divisoresPrimosEsperados = new int[] { 647 };

            //act
            var resultado = servOperacoesNumericas.AnalisaNumero(numero);

            //assert
            CollectionAssert.AreEqual(resultado.NumerosDivisores, numerosDivisoresEsperados);
            CollectionAssert.AreEqual(resultado.DivisoresPrimos, divisoresPrimosEsperados);
        }
    }
}
