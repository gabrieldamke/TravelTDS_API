using Domain.Entities;

namespace Domain.Contracts
{
    public interface IHotelService
    {
        Task<List<Hotel>> ObterHoteis();
        Task<Hotel> ObterHotelPorId(int id);
        Task<Hotel> AdicionarHotel(Hotel hotel);
        Task<Hotel> AtualizarHotel(Hotel hotel);
        Task<Hotel> DeletarHotel(int id);
    }
}