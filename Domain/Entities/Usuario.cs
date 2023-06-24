using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
namespace Domain.Entities
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<Viagem> Viagens { get; set; }

        public string ImagemPerfilBase64 { get; set; }

        public string TipoPermissao { get; set; }

        public Usuario(string email, string senha, string nome, string telefone, string imagemPerfilBase64, string TipoPermissao)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            Telefone = telefone;
            Viagens = new List<Viagem>();
            ImagemPerfilBase64 = imagemPerfilBase64;
            this.TipoPermissao = TipoPermissao;
        }
    }
}
