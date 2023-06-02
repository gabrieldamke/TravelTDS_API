using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class AtracaoTuristicaService : IAtracaoTuristicaService
    {
        private readonly DataContext _context;

        public AtracaoTuristicaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<AtracaoTuristica>> ObterAtracoesTuristicas()
        {
            return await _context.AtracoesTuristicas.ToListAsync();
        }

        public async Task<AtracaoTuristica> ObterAtracoesTuristicasId(int id)
        {
            return await _context.AtracoesTuristicas.FindAsync(id);
        }

        public async Task<AtracaoTuristica> AdicionarAtracaoTuristica(AtracaoTuristica atracaoTuristica)
        {
            try
            {
                _context.AtracoesTuristicas.Add(atracaoTuristica);
                await _context.SaveChangesAsync();
                return atracaoTuristica;
            }
            catch 
            {
                throw;
            }
        }
    }
}
