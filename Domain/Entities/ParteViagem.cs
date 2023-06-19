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
        public Destino Destino { get; set; }

        public DateTime DataInical { get; set; }

        public DateTime DataFinal { get; set; }

        public ParteViagem()
        {
            
        }
    }
}
