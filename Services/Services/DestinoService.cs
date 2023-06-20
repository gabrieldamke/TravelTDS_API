using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly DataContext _context;

        public DestinoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Destino>> ObterDestinos()
        {
            return await _context.Destinos.AsNoTracking().ToListAsync();
        }

        public async Task<Destino> ObterDestinoPorId(int id)
        {
            return await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Destino> AdicionarDestino(Destino destino)
        {
            try
            {
                _context.Destinos.Add(destino);
                await _context.SaveChangesAsync();
                return destino;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Destino> AtualizarDestino(Destino destino)
        {
            var destinoExistente = await _context.Destinos.FirstOrDefaultAsync(d => d.Id == destino.Id);
            if (destinoExistente == null)
            {
                throw new InvalidOperationException("Destino não encontrado");
            }

            try
            {
                destinoExistente.Nome = destino.Nome;
                destinoExistente.Descricao = destino.Descricao;
                destinoExistente.Restaurantes = destino.Restaurantes;
                destinoExistente.Atracoes = destino.Atracoes;
                destinoExistente.local = destino.local;
                destinoExistente.Hoteis = destino.Hoteis;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return destino;
        }

        public async Task<Destino> DeletarDestino(int id)
        {
            var destino = await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id);
            if (destino == null)
            {
                throw new InvalidOperationException("Destino não encontrado");
            }

            _context.Destinos.Remove(destino);
            await _context.SaveChangesAsync();

            return destino;
        }
    }
}