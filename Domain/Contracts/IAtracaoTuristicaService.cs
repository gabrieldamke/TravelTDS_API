using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IAtracaoTuristicaService
    {
        Task<List<AtracaoTuristica>> ObterAtracoesTuristicas();

        Task<AtracaoTuristica> ObterAtracoesTuristicasId(int id);

        Task<AtracaoTuristica> AdicionarAtracaoTuristica(AtracaoTuristica atracaoTuristica);

        Task<AtracaoTuristica> AtualizarAtracaoTuristica(AtracaoTuristica atracaoTuristica);

        Task<AtracaoTuristica> DeletarAtracaoTuristica(int id);
    }
}
