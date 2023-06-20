namespace Services.Services
{
    using Data;
    using Domain.Contracts;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace Services.Services
    {
        public class ParteViagemService : IParteViagemService
        {
            private readonly DataContext _context;

            public ParteViagemService(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ParteViagem>> ObterPartesViagem()
            {
                return await _context.PartesViagem.AsNoTracking().ToListAsync();
            }

            public async Task<ParteViagem> ObterParteViagemPorId(int id)
            {
                return await _context.PartesViagem.FirstOrDefaultAsync(p => p.Id == id);
            }

            public async Task<ParteViagem> AdicionarParteViagem(ParteViagem parteViagem)
            {
                try
                {
                    _context.PartesViagem.Add(parteViagem);
                    await _context.SaveChangesAsync();
                    return parteViagem;
                }
                catch
                {
                    throw;
                }
            }

            public async Task<ParteViagem> AtualizarParteViagem(ParteViagem parteViagem)
            {
                var parteViagemExistente = await _context.PartesViagem.FirstOrDefaultAsync(p => p.Id == parteViagem.Id);
                if (parteViagemExistente == null)
                {
                    throw new InvalidOperationException("Parte de viagem não encontrada");
                }

                try
                {
                    parteViagemExistente.IdViagem = parteViagem.IdViagem;
                    parteViagemExistente.restaurantesVisitados = parteViagem.restaurantesVisitados;
                    parteViagemExistente.Hotel = parteViagem.Hotel;
                    parteViagemExistente.atracoesVisitadas = parteViagem.atracoesVisitadas;
                    parteViagemExistente.DataInicial = parteViagem.DataInicial;
                    parteViagemExistente.DataFinal = parteViagem.DataFinal;

                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }

                return parteViagem;
            }

            public async Task<ParteViagem> DeletarParteViagem(int id)
            {
                var parteViagem = await _context.PartesViagem.FirstOrDefaultAsync(p => p.Id == id);
                if (parteViagem == null)
                {
                    throw new InvalidOperationException("Parte de viagem não encontrada");
                }

                _context.PartesViagem.Remove(parteViagem);
                await _context.SaveChangesAsync();
                return parteViagem;
            }
        }
    }
}
