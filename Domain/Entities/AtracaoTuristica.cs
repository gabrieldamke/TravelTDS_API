using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AtracaoTuristica : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;

        public AtracaoTuristica(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public AtracaoTuristica()
        {

        }
    }
}
