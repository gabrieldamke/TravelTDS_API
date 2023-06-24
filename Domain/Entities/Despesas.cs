using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Despesas : IEntity
    {
        public int Id { get; set; }
        public decimal CustosTransporte { get; set; }

        public decimal CustosHospedagem {  get; set; }
        
        public decimal CustosAtracoesTuristicas { get; set; }

        public decimal CustosRestaurantes { get; set; }

        public decimal CustosExtras { get; set; }

        public Despesas() { 
        }
    }
}
