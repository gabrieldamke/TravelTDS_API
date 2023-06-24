using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Local : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string ImagemLocal { get; set; }

        public Local(string nome, string endereco, string cidade, string estado, string pais)
        {
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public Local()
        {
        }
    }

}
