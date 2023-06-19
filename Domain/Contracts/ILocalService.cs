using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ILocalService
    {
        Task<List<Local>> ObterLocais();
        Task<Local> ObterLocalPorId(int id);
        Task<Local> AdicionarLocal(Local local);
        Task<Local> AtualizarLocal(Local local);
        Task<Local> DeletarLocal(int id);
    }
}
