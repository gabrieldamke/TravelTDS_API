﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AtracaoTuristica : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;

        public string ImagemBase64 { get; set; }

        public AtracaoTuristica(string nome, string descricao, string imagemBase64)
        {
            Nome = nome;
            Descricao = descricao;
            ImagemBase64 = imagemBase64;
        }

        public AtracaoTuristica()
        {

        }
    }
}
