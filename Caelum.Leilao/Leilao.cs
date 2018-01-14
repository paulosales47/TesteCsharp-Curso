using System;
using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public List<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            
            if ((PrimeiroLance() || !UsuarioUltimoLance().Equals(lance.Usuario)) && (QtdLancesUsuario(lance) < 5))
            {
                Lances.Add(lance);
            }
        }

        private int QtdLancesUsuario(Lance lance)
        {
            int qtdLances = 0;
            foreach (var item in this.Lances)
            {
                if (item.Usuario.Equals(lance.Usuario))
                {
                    qtdLances++;
                }
            }
            return qtdLances;
        }

        private bool PrimeiroLance()
        {
            return this.Lances.Count == 0;
        }

        private Usuario UsuarioUltimoLance()
        {
            int qtdLances = this.Lances.Count;
            
            return this.Lances[qtdLances -1] .Usuario;
        }

        public void DobraLance(Usuario usuario)
        {
            Lance ultimoLanceUsuario = this.Lances.FindLast(lance => lance.Usuario.Equals(usuario));
            double valorLance = ultimoLanceUsuario.Valor * 2;
            this.Propoe(new Lance(usuario, valorLance));
        }
    }
}