using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private IList<Lance> maiores;
        private double media = 0;
        

        public double MediaLance { get { return media; } }
        public double MaiorLance { get { return maiorDeTodos; } }
        public double MenorLance { get { return menorDeTodos; } }
        public IList<Lance> TresMaiores{ get { return this.maiores; }}

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0)
                throw new ArgumentException("Não é possível avaliar leilões sem lances");

            leilao.Lances.ForEach(lance => {
                if (lance.Valor < 1)
                    throw new ArgumentException("Não pode exisitir lances com valor igual a zero ou negativo");
            });
            
            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
            }

            pegaOsMaioresNo(leilao);
        }

        public void AvaliaLanceMedio(Leilao leilao)
        {
            media = leilao.Lances.Average(l => l.Valor);
        }

        private void pegaOsMaioresNo(Leilao leilao)
        {
            int qtdLances = leilao.Lances.Count;
            var filtro = leilao.Lances.OrderByDescending(p => p.Valor).Take( qtdLances < 3 ? qtdLances : 3 );
            maiores = new List<Lance>(filtro);
        }

    }
}

