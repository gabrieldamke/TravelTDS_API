using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParteViagem : IEntity
    {
        public int Id { get; set; }
        public int IdViagem { get; set; }
        public Hotel Hotel { get; set; }

        public AtracaoTuristica atracoesVisitadas { get; set; }
        
        public Restaurante restaurantesVisitados { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public ParteViagem()
        {
            
        }
    }
}
