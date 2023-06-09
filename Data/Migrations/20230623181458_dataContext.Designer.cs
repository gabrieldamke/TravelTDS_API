﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230623181458_dataContext")]
    partial class dataContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtracaoTuristicaDestino", b =>
                {
                    b.Property<int>("AtracoesId")
                        .HasColumnType("int");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.HasKey("AtracoesId", "DestinoId");

                    b.HasIndex("DestinoId");

                    b.ToTable("Destino_AtracaoTuristica", (string)null);
                });

            modelBuilder.Entity("AtracaoTuristicaParteViagem", b =>
                {
                    b.Property<int>("ParteViagemId")
                        .HasColumnType("int");

                    b.Property<int>("atracoesVisitadasId")
                        .HasColumnType("int");

                    b.HasKey("ParteViagemId", "atracoesVisitadasId");

                    b.HasIndex("atracoesVisitadasId");

                    b.ToTable("ParteViagem_AtracaoTuristica", (string)null);
                });

            modelBuilder.Entity("DestinoHotel", b =>
                {
                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("HoteisId")
                        .HasColumnType("int");

                    b.HasKey("DestinoId", "HoteisId");

                    b.HasIndex("HoteisId");

                    b.ToTable("Destino_Hotel", (string)null);
                });

            modelBuilder.Entity("DestinoRestaurante", b =>
                {
                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantesId")
                        .HasColumnType("int");

                    b.HasKey("DestinoId", "RestaurantesId");

                    b.HasIndex("RestaurantesId");

                    b.ToTable("Destino_Restaurante", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AtracaoTuristica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocalId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ValorIngresso")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("AtracoesTuristicas");
                });

            modelBuilder.Entity("Domain.Entities.Destino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<string>("ImagemBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("Hoteis");
                });

            modelBuilder.Entity("Domain.Entities.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("Domain.Entities.ParteViagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("IdViagem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("IdViagem");

                    b.ToTable("PartesViagem");
                });

            modelBuilder.Entity("Domain.Entities.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagemBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoCozinhaId")
                        .HasColumnType("int");

                    b.Property<float>("valorMedio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.HasIndex("TipoCozinhaId");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("Domain.Entities.TipoCozinha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoCozinha");
                });

            modelBuilder.Entity("Domain.Entities.TipoQuarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoDiaria")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TipoQuarto");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemPerfilBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPermissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Viagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Orcamento")
                        .HasColumnType("real");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("HotelTipoQuarto", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("TiposQuartoId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "TiposQuartoId");

                    b.HasIndex("TiposQuartoId");

                    b.ToTable("Hotel_TipoQuarto", (string)null);
                });

            modelBuilder.Entity("ParteViagemRestaurante", b =>
                {
                    b.Property<int>("ParteViagemId")
                        .HasColumnType("int");

                    b.Property<int>("restaurantesVisitadosId")
                        .HasColumnType("int");

                    b.HasKey("ParteViagemId", "restaurantesVisitadosId");

                    b.HasIndex("restaurantesVisitadosId");

                    b.ToTable("ParteViagem_Restaurante", (string)null);
                });

            modelBuilder.Entity("AtracaoTuristicaDestino", b =>
                {
                    b.HasOne("Domain.Entities.AtracaoTuristica", null)
                        .WithMany()
                        .HasForeignKey("AtracoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Destino", null)
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AtracaoTuristicaParteViagem", b =>
                {
                    b.HasOne("Domain.Entities.ParteViagem", null)
                        .WithMany()
                        .HasForeignKey("ParteViagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AtracaoTuristica", null)
                        .WithMany()
                        .HasForeignKey("atracoesVisitadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DestinoHotel", b =>
                {
                    b.HasOne("Domain.Entities.Destino", null)
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HoteisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DestinoRestaurante", b =>
                {
                    b.HasOne("Domain.Entities.Destino", null)
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Restaurante", null)
                        .WithMany()
                        .HasForeignKey("RestaurantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AtracaoTuristica", b =>
                {
                    b.HasOne("Domain.Entities.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Local");
                });

            modelBuilder.Entity("Domain.Entities.Destino", b =>
                {
                    b.HasOne("Domain.Entities.Local", "local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("local");
                });

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.HasOne("Domain.Entities.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Local");
                });

            modelBuilder.Entity("Domain.Entities.ParteViagem", b =>
                {
                    b.HasOne("Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Viagem", "Viagem")
                        .WithMany("PartesViagem")
                        .HasForeignKey("IdViagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Viagem");
                });

            modelBuilder.Entity("Domain.Entities.Restaurante", b =>
                {
                    b.HasOne("Domain.Entities.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoCozinha", "TipoCozinha")
                        .WithMany()
                        .HasForeignKey("TipoCozinhaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("TipoCozinha");
                });

            modelBuilder.Entity("Domain.Entities.Viagem", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("Viagens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HotelTipoQuarto", b =>
                {
                    b.HasOne("Domain.Entities.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoQuarto", null)
                        .WithMany()
                        .HasForeignKey("TiposQuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParteViagemRestaurante", b =>
                {
                    b.HasOne("Domain.Entities.ParteViagem", null)
                        .WithMany()
                        .HasForeignKey("ParteViagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Restaurante", null)
                        .WithMany()
                        .HasForeignKey("restaurantesVisitadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Viagens");
                });

            modelBuilder.Entity("Domain.Entities.Viagem", b =>
                {
                    b.Navigation("PartesViagem");
                });
#pragma warning restore 612, 618
        }
    }
}
