using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Viagem
    {
        public Destino Destino { get; set; }
        public DateTime DataViagem { get; set; }

        public Viagem(Destino destino, DateTime dataViagem)
        {
            Destino = destino;
            DataViagem = dataViagem;
        }
    }
}
