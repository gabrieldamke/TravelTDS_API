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

        public string ImagemBase64 { get; set; }

        public Hotel(string nome, string endereco, int classificacao, string imagemBase64)
        {
            Nome = nome;
            Endereco = endereco;
            Classificacao = classificacao;
            ImagemBase64 = imagemBase64;
        }
    }
}
