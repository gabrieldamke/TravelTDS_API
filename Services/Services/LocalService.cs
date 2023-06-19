using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LocalService : ILocalService
    {
        private readonly DataContext _context;

        public LocalService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Local>> ObterLocais()
        {
            return await _context.Locais.AsNoTracking().ToListAsync();
        }

        public async Task<Local> ObterLocalPorId(int id)
        {
            return await _context.Locais.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Local> AdicionarLocal(Local local)
        {
            try
            {
                _context.Locais.Add(local);
                await _context.SaveChangesAsync();
                return local;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Local> AtualizarLocal(Local local)
        {
            var localExistente = await _context.Locais.FirstOrDefaultAsync(l => l.Id == local.Id);
            if (localExistente == null)
            {
                throw new InvalidOperationException("Local não encontrado");
            }
            try
            {
                localExistente.Nome = local.Nome;
                localExistente.Endereco = local.Endereco;
                localExistente.Cidade = local.Cidade;
                localExistente.Estado = local.Estado;
                localExistente.Pais = local.Pais;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return local;
        }

        public async Task<Local> DeletarLocal(int id)
        {
            var local = await _context.Locais.FirstOrDefaultAsync(l => l.Id == id);
            if (local == null)
            {
                throw new InvalidOperationException("Local não encontrado");
            }
            _context.Locais.Remove(local);
            await _context.SaveChangesAsync();
            return local;
        }
    }
}
