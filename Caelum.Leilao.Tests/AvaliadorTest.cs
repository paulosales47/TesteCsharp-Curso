using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    class AvaliadorTest
    {
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TestLanceMedio()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.AvaliaLanceMedio(leilao);

            // comparando a saida com o esperado
            double mediaEsperada = ((400.0 + 300.0 + 250.0) / 3);


            Assert.AreEqual(mediaEsperada, leiloeiro.MediaLance, 0.0001);
        }

        [Test]
        public void TesteUnicoLance()
        {
            // cenario: 1 lance
            Usuario joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 200.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(200, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(200, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TesteLancesRandom()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 450.0));
            leilao.Propoe(new Lance(jose, 120.0));
            leilao.Propoe(new Lance(jose, 700.0));
            leilao.Propoe(new Lance(jose, 630.0));
            leilao.Propoe(new Lance(jose, 230.0));
            
            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TesteLancesDecrescentes()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 600.0));
            leilao.Propoe(new Lance(jose, 500.0));
            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(jose, 300.0));
            leilao.Propoe(new Lance(jose, 200.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(200, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void TesteMaiores4Lances()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 900.0));
            leilao.Propoe(new Lance(jose, 500.0));
            leilao.Propoe(new Lance(jose, 400.0));
            
            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var lista = leiloeiro.TresMaiores;


            Assert.AreEqual(3, lista.Count);
            Assert.AreEqual(900, lista[0].Valor);
            Assert.AreEqual(700, lista[1].Valor);
            Assert.AreEqual(500, lista[2].Valor);

        }

        [Test]
        public void TesteMaiores2Lances()
        {
            
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 900.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var lista = leiloeiro.TresMaiores;
            
            Assert.AreEqual(2, lista.Count);
            Assert.AreEqual(900, lista[0].Valor);
            Assert.AreEqual(700, lista[1].Valor);

        }

        [Test]
        public void TesteMaioresNenhumLance()
        {

            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var lista = leiloeiro.TresMaiores;

            Assert.AreEqual(0, lista.Count);
            Assert.IsEmpty(lista);

        }



    }
}
