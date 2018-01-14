using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {
        [OneTimeSetUp]
        public void ApenasInicio() => Console.WriteLine("Inicio Unico");

        [OneTimeTearDown]
        public void ApenasFim() => Console.WriteLine("Fim Unico");

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            
            Usuario joao = new Usuario("Joao");
            

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(joao, 450.0));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(200, leilao.Lances[0].Valor, 0.0001);
            

        }

        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");
            
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            leilao.Propoe(new Lance(joao, 500.0));
            leilao.Propoe(new Lance(maria, 600.0));

            leilao.Propoe(new Lance(joao, 700.0));
            leilao.Propoe(new Lance(maria, 800.0));

            leilao.Propoe(new Lance(joao, 900.0));
            leilao.Propoe(new Lance(maria, 1000.0));

            leilao.Propoe(new Lance(joao, 1100.0));
            leilao.Propoe(new Lance(maria, 1200.0));

            Assert.AreEqual(10, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances[9].Valor, 0.0001);
        }

        [Test]
        public void VerificaDobraLance()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 150.0));
            leilao.Propoe(new Lance(maria, 200.0));
            
            leilao.DobraLance(joao);

            Assert.AreEqual(5, leilao.Lances.Count);
            Assert.AreEqual(100, leilao.Lances[0].Valor, 0.0001);
            Assert.AreEqual(200, leilao.Lances[1].Valor, 0.0001);
            Assert.AreEqual(150, leilao.Lances[2].Valor, 0.0001);
            Assert.AreEqual(200, leilao.Lances[3].Valor, 0.0001);
            Assert.AreEqual(300, leilao.Lances[4].Valor, 0.0001);

        }

    }
}


