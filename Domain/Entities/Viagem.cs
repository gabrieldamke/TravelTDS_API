using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Viagem : IEntity
    {
        public int Id { get; set; }
        public List<ParteViagem> PartesViagem { get; set; }

        public Viagem()
        {
          
        }
    }
}
