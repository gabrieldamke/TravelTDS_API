using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IParteViagemService
    {
        Task<List<ParteViagem>> ObterPartesViagem();
        Task<ParteViagem> ObterParteViagemPorId(int id);
        Task<ParteViagem> AdicionarParteViagem(ParteViagem parteViagem);
        Task<ParteViagem> AtualizarParteViagem(ParteViagem parteViagem);
        Task<ParteViagem> DeletarParteViagem(int id);
    }
}
