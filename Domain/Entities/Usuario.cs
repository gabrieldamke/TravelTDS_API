using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<Viagem> Itinerario { get; set; }

        public Usuario(string email, string senha, string nome, string telefone)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            Telefone = telefone;
            Itinerario = new List<Viagem>();
        }
    }
}
