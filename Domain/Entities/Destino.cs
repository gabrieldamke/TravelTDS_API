using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Destino : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        public Local local { get; set; }
        public List<AtracaoTuristica> Atracoes { get; set; }
        public List<Hotel> Hoteis { get; set; }
        public List<Restaurante> Restaurantes { get; set; }

        public Destino(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Atracoes = new List<AtracaoTuristica>();
            Hoteis = new List<Hotel>();
            Restaurantes = new List<Restaurante>();
            local = new Local();
        }
    }
}
