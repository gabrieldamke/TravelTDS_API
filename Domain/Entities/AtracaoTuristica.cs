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

        public float ValorIngresso { get; set; }

        public string ImagemBase64 { get; set; }

        public AtracaoTuristica(string nome, string descricao, float valorIngresso,  string imagemBase64)
        {
            Nome = nome;
            Descricao = descricao;
            ImagemBase64 = imagemBase64;
            ValorIngresso = valorIngresso;
        }

        public AtracaoTuristica()
        {

        }
    }
}
