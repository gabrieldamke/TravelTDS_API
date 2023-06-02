using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Restaurante : IEntity
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string TipoCozinha { get; set; }

        public Restaurante(string nome, string endereco, string tipoCozinha)
        {
            Nome = nome;
            Endereco = endereco;
            TipoCozinha = tipoCozinha;
        }
    }
}
