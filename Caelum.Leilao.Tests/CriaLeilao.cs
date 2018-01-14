using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    public class CriaLeilao
    {

        private Leilao leilao;
        private IList<Usuario> lUsuario;

        public Leilao Leilao { get { return this.leilao; } }
        
        public CriaLeilao(string descricaoLeilao)
        {
            this.leilao = new Leilao("Leilao");
        }
        
        public CriaLeilao Lance(int indexUsuario, double valor)
        {
            this.leilao.Propoe(new Lance(lUsuario[indexUsuario], valor));
            return this;
        }

        public CriaLeilao GeraUsuarios(int qtdUsuario)
        {
            this.lUsuario = new List<Usuario>();

            for (int i = 0; i < qtdUsuario; i++)
            {
                lUsuario.Add(new Usuario($"usuario_{i}"));
            }

            return this;
        }
        
    }
}
