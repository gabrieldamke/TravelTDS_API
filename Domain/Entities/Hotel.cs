﻿
namespace Domain.Entities
{
    public class Hotel : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Local Local { get; set; }

        public int LocalId { get; set; }
        public int Classificacao { get; set; }

        public ICollection<TipoQuarto> TiposQuarto { get; set; }

        public string ImagemBase64 { get; set; }

        public Hotel(string nome, string endereco, int classificacao, string imagemBase64, Local local)
        {
            Nome = nome;
            Local = local;
            Classificacao = classificacao;
            ImagemBase64 = imagemBase64;
            TiposQuarto = new List<TipoQuarto>();
        }

        public Hotel() { }
    }
}
