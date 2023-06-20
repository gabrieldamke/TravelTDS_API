using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class AtracaoTuristicaService : IAtracaoTuristicaService
    {
        private readonly DataContext _context;

        public AtracaoTuristicaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<AtracaoTuristica>> ObterAtracoesTuristicas()
        {
            return await _context.AtracoesTuristicas.AsNoTracking().ToListAsync();
        }

        public async Task<AtracaoTuristica> ObterAtracoesTuristicasId(int id)
        {
            return await _context.AtracoesTuristicas.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AtracaoTuristica> AdicionarAtracaoTuristica(AtracaoTuristica atracaoTuristica)
        {
            try
            {
                _context.AtracoesTuristicas.Add(atracaoTuristica);
                await _context.SaveChangesAsync();
                return atracaoTuristica;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<AtracaoTuristica> AtualizarAtracaoTuristica(AtracaoTuristica atracaoTuristica)
        {
            var atracao = await _context.AtracoesTuristicas.FirstOrDefaultAsync(a => a.Id == atracaoTuristica.Id);
            if (atracao == null)
            {
                throw new InvalidOperationException("Atração turistica não encontrada");
            }
           try
            {
                atracao.Descricao = atracaoTuristica.Descricao;
                atracao.Nome = atracaoTuristica.Nome;
                atracao.ValorIngresso = atracao.ValorIngresso;

                await _context.SaveChangesAsync();
            } catch
            {
                throw;
            }
            return atracaoTuristica;
        }

        public async Task<AtracaoTuristica> DeletarAtracaoTuristica(int id)
        {
            var atracao = await _context.AtracoesTuristicas.FirstOrDefaultAsync(a => a.Id == id);
            if (atracao == null)
            {
                throw new InvalidOperationException("Atração turistica não encontrada");
            }
            _context.AtracoesTuristicas.Remove(atracao);
            await _context.SaveChangesAsync();
            return atracao;
        }
    }
}
