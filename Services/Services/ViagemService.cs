using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class ViagemService : IViagemService
    {
        private readonly DataContext _context;

        public ViagemService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Viagem>> ObterViagens()
        {
            return await _context.Viagens.AsNoTracking().ToListAsync();
        }

        public async Task<Viagem> ObterViagemPorId(int id)
        {
            return await _context.Viagens.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Viagem> AdicionarViagem(Viagem viagem)
        {
            try
            {
                _context.Viagens.Add(viagem);
                await _context.SaveChangesAsync();
                return viagem;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Viagem> AtualizarViagem(Viagem viagem)
        {
            var viagemExistente = await _context.Viagens.FirstOrDefaultAsync(v => v.Id == viagem.Id);
            if (viagemExistente == null)
            {
                throw new InvalidOperationException("Viagem não encontrada");
            }

            try
            {
                viagemExistente.PartesViagem = viagem.PartesViagem;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return viagem;
        }

        public async Task<Viagem> DeletarViagem(int id)
        {
            var viagem = await _context.Viagens.FirstOrDefaultAsync(v => v.Id == id);
            if (viagem == null)
            {
                throw new InvalidOperationException("Viagem não encontrada");
            }

            _context.Viagens.Remove(viagem);
            await _context.SaveChangesAsync();
            return viagem;
        }
    }
}