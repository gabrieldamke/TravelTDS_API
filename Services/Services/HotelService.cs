using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class HotelService : IHotelService
    {
        private readonly DataContext _context;

        public HotelService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> ObterHoteis()
        {
            return await _context.Hoteis.AsNoTracking().ToListAsync();
        }

        public async Task<Hotel> ObterHotelPorId(int id)
        {
            return await _context.Hoteis.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hotel> AdicionarHotel(Hotel hotel)
        {
            try
            {
                _context.Hoteis.Add(hotel);
                await _context.SaveChangesAsync();
                return hotel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Hotel> AtualizarHotel(Hotel hotel)
        {
            var hotelExistente = await _context.Hoteis.FirstOrDefaultAsync(h => h.Id == hotel.Id);
            if (hotelExistente == null)
            {
                throw new InvalidOperationException("Hotel não encontrado");
            }

            try
            {
                hotelExistente.Nome = hotel.Nome;
                hotelExistente.Endereco = hotel.Endereco;
                hotelExistente.Classificacao = hotel.Classificacao;
                hotelExistente.ImagemBase64 = hotel.ImagemBase64;
                hotelExistente.TiposQuarto = hotel.TiposQuarto;


                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return hotel;
        }

        public async Task<Hotel> DeletarHotel(int id)
        {
            var hotel = await _context.Hoteis.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                throw new InvalidOperationException("Hotel não encontrado");
            }

            _context.Hoteis.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }
    }
}