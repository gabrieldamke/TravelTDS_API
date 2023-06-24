using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParteViagem : IEntity
    {
        public int Id { get; set; }
        public int IdViagem { get; set; }

        public Viagem Viagem { get; set; }
        public Hotel Hotel { get; set; }
        public List<AtracaoTuristica> atracoesVisitadas { get; set; }
        
        public List<Restaurante> restaurantesVisitados { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public Despesas Despesas { get; set; }

        public int? DespesasId { get; set; }

        public ParteViagem()
        {
            
        }
    }
}
