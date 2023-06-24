using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public DbSet<Viagem> Viagens { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ParteViagem> PartesViagem { get; set; }

        public DbSet<Hotel> Hoteis { get; set; }

        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Viagem>(entity =>
            {
                entity.HasOne(v => v.Usuario)
                    .WithMany(u => u.Viagens)
                    .HasForeignKey(v => v.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasMany(u => u.Viagens)
                    .WithOne(v => v.Usuario)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasOne(r => r.Local)
                    .WithMany()
                    .HasForeignKey(r => r.LocalId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.TipoCozinha)
                    .WithMany()
                    .HasForeignKey(r => r.TipoCozinhaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ParteViagem>(entity =>
            {
                entity.HasOne(p => p.Viagem)
                    .WithMany(v => v.PartesViagem)
                    .HasForeignKey(p => p.IdViagem)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.restaurantesVisitados)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("ParteViagem_Restaurante"));

                entity.HasMany(p => p.atracoesVisitadas)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("ParteViagem_AtracaoTuristica"));

                entity.HasOne(p => p.Despesas)
                   .WithOne()
                 .  HasForeignKey<ParteViagem>(p => p.DespesasId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasOne(h => h.Local)
                    .WithMany()
                    .HasForeignKey(h => h.LocalId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(h => h.TiposQuarto)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("Hotel_TipoQuarto"));
            });

            modelBuilder.Entity<Local>(entity => { entity.HasKey((l) => l.Id); });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.HasOne(d => d.local)
                    .WithMany()
                    .HasForeignKey(d => d.LocalId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.Atracoes)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("Destino_AtracaoTuristica"));

                entity.HasMany(d => d.Hoteis)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("Destino_Hotel"));

                entity.HasMany(d => d.Restaurantes)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("Destino_Restaurante"));


            });

            modelBuilder.Entity<AtracaoTuristica>(entity =>
            {
                entity.HasOne(a => a.Local)
                    .WithMany()
                    .HasForeignKey(a => a.LocalId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }



    }
}


