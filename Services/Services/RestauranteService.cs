using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly DataContext _context;

        public RestauranteService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurante>> ObterRestaurantes()
        {
            return await _context.Restaurantes.AsNoTracking().ToListAsync();
        }

        public async Task<Restaurante> ObterRestaurantePorId(int id)
        {
            return await _context.Restaurantes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Restaurante> AdicionarRestaurante(Restaurante restaurante)
        {
            try
            {
                _context.Restaurantes.Add(restaurante);
                await _context.SaveChangesAsync();
                return restaurante;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Restaurante> AtualizarRestaurante(Restaurante restaurante)
        {
            var restauranteExistente = await _context.Restaurantes.FirstOrDefaultAsync(r => r.Id == restaurante.Id);
            if (restauranteExistente == null)
            {
                throw new InvalidOperationException("Restaurante não encontrado");
            }

            try
            {
                restauranteExistente.Nome = restaurante.Nome;
                restauranteExistente.Local = restaurante.Local;
                restauranteExistente.TipoCozinha = restaurante.TipoCozinha;
                restauranteExistente.ImagemBase64 = restaurante.ImagemBase64;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return restaurante;
        }

        public async Task<Restaurante> DeletarRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes.FirstOrDefaultAsync(r => r.Id == id);
            if (restaurante == null)
            {
                throw new InvalidOperationException("Restaurante não encontrado");
            }

            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();
            return restaurante;
        }
    }
}