using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caelum.Leilao.Tests;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    class AvaliadorTest
    {
        private Avaliador leiloeiro;

        //EXECUTADO APENAS UMA VEZ NA INICIALIZAÇÃO
        //[OneTimeSetUp]
        //public void ApenasInicio()
        //{
        //    Console.WriteLine("Inicio Unico");
        //}

        //EXECUTADO NO INICIO DE CADA TESTE
        [SetUp]
        public void InicializaAvaliador()
        {
            this.leiloeiro = new Avaliador();
            Console.WriteLine("Iniciando testes");
        }

        //EXECUTADO SOMENTE NO FIM DE TODOS OS TESTES
        //[OneTimeTearDown]
        //public void ApenasFim()
        //{
        //    Console.WriteLine("Fim Unico");
        //}

        ////EXECUTADO AO FIM DE CADA TESTE
        //[TearDown]
        //public void Finaliza()
        //{
        //    Console.WriteLine("fim");
        //}

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(3)
                .Lance(0, 500.0)
                .Lance(1, 1000.0)
                .Lance(2, 7000.0)
                .Leilao;

            this.leiloeiro.Avalia(leilao);

            Assert.AreEqual(7000, this.leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(500, this.leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TestLanceMedio()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(3)
                .Lance(0, 250.0)
                .Lance(1, 300.0)
                .Lance(2, 400.0)
                .Leilao;

            this.leiloeiro.AvaliaLanceMedio(leilao);

            double mediaEsperada = ((400.0 + 300.0 + 250.0) / 3);

            Assert.AreEqual(mediaEsperada, this.leiloeiro.MediaLance, 0.0001);
        }

        [Test]
        public void TesteUnicoLance()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(1)
                .Lance(0, 200.0)
                .Leilao;

            // executando a acao
            this.leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(200, this.leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(200, this.leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TesteLancesRandom()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(3)
                .Lance(0, 200.0)
                .Lance(1, 450.0)
                .Lance(2, 120.0)
                .Lance(0, 700.0)
                .Lance(2, 630.0)
                .Lance(0, 230.0)
                .Leilao;

            // executando a acao
            this.leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(700, this.leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120, this.leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TesteLancesDecrescentes()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(3)
                .Lance(0, 700.0)
                .Lance(1, 600.0)
                .Lance(2, 500.0)
                .Lance(0, 400.0)
                .Lance(2, 300.0)
                .Lance(0, 200.0)
                .Leilao;

            // executando a acao
            this.leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(700, this.leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(200, this.leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TesteMaiores4Lances()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(3)
                .Lance(0, 700.0)
                .Lance(1, 900.0)
                .Lance(2, 500.0)
                .Lance(0, 400.0)
                .Leilao;

            // executando a acao
            this.leiloeiro.Avalia(leilao);

            var lista = this.leiloeiro.TresMaiores;
            
            Assert.AreEqual(3, lista.Count);
            Assert.AreEqual(900, lista[0].Valor);
            Assert.AreEqual(700, lista[1].Valor);
            Assert.AreEqual(500, lista[2].Valor);

        }

        [Test]
        public void TesteMaiores2Lances()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(2)
                .Lance(0, 700.0)
                .Lance(1, 900.0)
                .Leilao;

            // executando a acao
            this.leiloeiro.Avalia(leilao);

            var lista = this.leiloeiro.TresMaiores;
            
            Assert.AreEqual(2, lista.Count);
            Assert.AreEqual(900, lista[0].Valor);
            Assert.AreEqual(700, lista[1].Valor);

        }

        [Test]
        public void TesteMaioresNenhumLance()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(0)
                .Leilao;
            
            Assert.Throws<ArgumentException>(() => this.leiloeiro.Avalia(leilao));
            
        }

        [Test]
        public void TestaLanceZeroeNegativo()
        {
            Leilao leilao = new CriaLeilao("Carro")
                .GeraUsuarios(2)
                .Lance(0, 0)
                .Lance(1, -1)
                .Leilao;
            
            Assert.Throws<ArgumentException>(() => this.leiloeiro.Avalia(leilao));
        }


    }
}
