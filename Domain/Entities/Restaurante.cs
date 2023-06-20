using Domain.Enums;
namespace Domain.Entities
{
    public class Restaurante : IEntity
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public Local Local { get; set; }

        public int LocalId { get; set; } 
        public TipoCozinha TipoCozinha { get; set; }

        public string ImagemBase64 { get; set; }

        public float valorMedio { get; set; }

        public Restaurante(string nome, Local local, TipoCozinha tipoCozinha, string imagemBase64)
        {
            Nome = nome;
            Local = local;
            TipoCozinha = tipoCozinha;
            ImagemBase64 = imagemBase64;
        }

        public Restaurante() { 
            
        }
    }
}
