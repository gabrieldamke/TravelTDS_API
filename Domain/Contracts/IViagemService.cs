using Domain.Entities;

namespace Domain.Contracts
{
    public interface IViagemService
    {
        Task<List<Viagem>> ObterViagens();
        Task<Viagem> ObterViagemPorId(int id);
        Task<Viagem> AdicionarViagem(Viagem viagem);
        Task<Viagem> AtualizarViagem(Viagem viagem);
        Task<Viagem> DeletarViagem(int id);
    }
}
