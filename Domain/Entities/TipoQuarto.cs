﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoQuarto : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoDiaria { get; set; }

    }
}
