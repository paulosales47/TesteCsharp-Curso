using System.Collections.Generic;

namespace Caelum.Leilao
{

    public class Usuario
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Usuario(string nome) : this(0, nome)
        {
        }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public override bool Equals(object obj)
        {
            var usuario = obj as Usuario;
            return usuario != null &&
                   Id == usuario.Id &&
                   Nome == usuario.Nome;
        }

        public override int GetHashCode()
        {
            var hashCode = -1643562096;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
    }
}
