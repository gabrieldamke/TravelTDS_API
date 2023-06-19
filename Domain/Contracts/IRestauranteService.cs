using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRestauranteService
    {
        Task<List<Restaurante>> ObterRestaurantes();
        Task<Restaurante> ObterRestaurantePorId(int id);
        Task<Restaurante> AdicionarRestaurante(Restaurante restaurante);
        Task<Restaurante> AtualizarRestaurante(Restaurante restaurante);
        Task<Restaurante> DeletarRestaurante(int id);
    }
}
