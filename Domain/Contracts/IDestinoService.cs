using Domain.Entities;

namespace Domain.Contracts
{
    public interface IDestinoService
    {
        Task<List<Destino>> ObterDestinos();
        Task<Destino> ObterDestinoPorId(int id);
        Task<Destino> AdicionarDestino(Destino destino);
        Task<Destino> AtualizarDestino(Destino destino);
        Task<Destino> DeletarDestino(int id);
    }
}