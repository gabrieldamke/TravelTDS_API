using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Classificacao { get; set; }

        public Hotel(string nome, string endereco, int classificacao)
        {
            Nome = nome;
            Endereco = endereco;
            Classificacao = classificacao;
        }
    }
}
