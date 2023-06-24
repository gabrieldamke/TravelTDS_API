using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObterUsuarios();
        Task<Usuario> ObterUsuarioPorId(int id);

        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario);
        Task<Usuario> DeletarUsuario(int id);

        Task<bool> validarLogin(Authentication auth);

        Task<bool> VerificarEmailExiste(string email);
    }
}
