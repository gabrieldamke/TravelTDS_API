using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataContext _context;

        public UsuarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);
            if (usuarioExistente == null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            try
            {
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Senha = usuario.Senha;
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Telefone = usuario.Telefone;
                usuarioExistente.ImagemPerfilBase64 = usuario.ImagemPerfilBase64;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return usuario;
        }

        public async Task<Usuario> DeletarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}