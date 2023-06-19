using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
        public DbSet<AtracaoTuristica> AtracoesTuristicas { get; set; }

        public DbSet<Local> Locais { get; set; }

        public DbSet<Restaurante> Restaurantes { get; set; }

        public DbSet<Viagem> Viagens { get; set;    }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ParteViagem> PartesViagem { get; set; }

        public DbSet<Hotel> Hoteis { get; set; }

        public DbSet<Destino> Destinos { get; set; }

    }
}
