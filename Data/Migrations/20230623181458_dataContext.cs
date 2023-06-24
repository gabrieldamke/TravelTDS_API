using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class dataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtracoesTuristicas_Destinos_DestinoId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtracoesTuristicas_Locais_LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtracoesTuristicas_PartesViagem_ParteViagemId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_Locais_localId",
                table: "Destinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteis_Destinos_DestinoId",
                table: "Hoteis");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteis_Locais_LocalId",
                table: "Hoteis");

            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Viagens_ViagemId",
                table: "PartesViagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurantes_Destinos_DestinoId",
                table: "Restaurantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurantes_PartesViagem_ParteViagemId",
                table: "Restaurantes");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoQuarto_Hoteis_HotelId",
                table: "TipoQuarto");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Usuarios_UsuarioId",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_TipoQuarto_HotelId",
                table: "TipoQuarto");

            migrationBuilder.DropIndex(
                name: "IX_Restaurantes_DestinoId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurantes_LocalId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurantes_ParteViagemId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_ViagemId",
                table: "PartesViagem");

            migrationBuilder.DropIndex(
                name: "IX_Hoteis_DestinoId",
                table: "Hoteis");

            migrationBuilder.DropIndex(
                name: "IX_Hoteis_LocalId",
                table: "Hoteis");

            migrationBuilder.DropIndex(
                name: "IX_AtracoesTuristicas_DestinoId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropIndex(
                name: "IX_AtracoesTuristicas_LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropIndex(
                name: "IX_AtracoesTuristicas_ParteViagemId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "TipoQuarto");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "ParteViagemId",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "ViagemId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "Hoteis");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropColumn(
                name: "ParteViagemId",
                table: "AtracoesTuristicas");

            migrationBuilder.RenameColumn(
                name: "TipoCozinha",
                table: "Restaurantes",
                newName: "TipoCozinhaId");

            migrationBuilder.RenameColumn(
                name: "localId",
                table: "Destinos",
                newName: "LocalId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinos_localId",
                table: "Destinos",
                newName: "IX_Destinos_LocalId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Viagens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Destino_AtracaoTuristica",
                columns: table => new
                {
                    AtracoesId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino_AtracaoTuristica", x => new { x.AtracoesId, x.DestinoId });
                    table.ForeignKey(
                        name: "FK_Destino_AtracaoTuristica_AtracoesTuristicas_AtracoesId",
                        column: x => x.AtracoesId,
                        principalTable: "AtracoesTuristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destino_AtracaoTuristica_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destino_Hotel",
                columns: table => new
                {
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    HoteisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino_Hotel", x => new { x.DestinoId, x.HoteisId });
                    table.ForeignKey(
                        name: "FK_Destino_Hotel_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destino_Hotel_Hoteis_HoteisId",
                        column: x => x.HoteisId,
                        principalTable: "Hoteis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destino_Restaurante",
                columns: table => new
                {
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    RestaurantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino_Restaurante", x => new { x.DestinoId, x.RestaurantesId });
                    table.ForeignKey(
                        name: "FK_Destino_Restaurante_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destino_Restaurante_Restaurantes_RestaurantesId",
                        column: x => x.RestaurantesId,
                        principalTable: "Restaurantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel_TipoQuarto",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    TiposQuartoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_TipoQuarto", x => new { x.HotelId, x.TiposQuartoId });
                    table.ForeignKey(
                        name: "FK_Hotel_TipoQuarto_Hoteis_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotel_TipoQuarto_TipoQuarto_TiposQuartoId",
                        column: x => x.TiposQuartoId,
                        principalTable: "TipoQuarto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParteViagem_AtracaoTuristica",
                columns: table => new
                {
                    ParteViagemId = table.Column<int>(type: "int", nullable: false),
                    atracoesVisitadasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParteViagem_AtracaoTuristica", x => new { x.ParteViagemId, x.atracoesVisitadasId });
                    table.ForeignKey(
                        name: "FK_ParteViagem_AtracaoTuristica_AtracoesTuristicas_atracoesVisitadasId",
                        column: x => x.atracoesVisitadasId,
                        principalTable: "AtracoesTuristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParteViagem_AtracaoTuristica_PartesViagem_ParteViagemId",
                        column: x => x.ParteViagemId,
                        principalTable: "PartesViagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParteViagem_Restaurante",
                columns: table => new
                {
                    ParteViagemId = table.Column<int>(type: "int", nullable: false),
                    restaurantesVisitadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParteViagem_Restaurante", x => new { x.ParteViagemId, x.restaurantesVisitadosId });
                    table.ForeignKey(
                        name: "FK_ParteViagem_Restaurante_PartesViagem_ParteViagemId",
                        column: x => x.ParteViagemId,
                        principalTable: "PartesViagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParteViagem_Restaurante_Restaurantes_restaurantesVisitadosId",
                        column: x => x.restaurantesVisitadosId,
                        principalTable: "Restaurantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoCozinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCozinha", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_LocalId",
                table: "Restaurantes",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_TipoCozinhaId",
                table: "Restaurantes",
                column: "TipoCozinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_IdViagem",
                table: "PartesViagem",
                column: "IdViagem");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteis_LocalId",
                table: "Hoteis",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_AtracoesTuristicas_LocalId",
                table: "AtracoesTuristicas",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Destino_AtracaoTuristica_DestinoId",
                table: "Destino_AtracaoTuristica",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Destino_Hotel_HoteisId",
                table: "Destino_Hotel",
                column: "HoteisId");

            migrationBuilder.CreateIndex(
                name: "IX_Destino_Restaurante_RestaurantesId",
                table: "Destino_Restaurante",
                column: "RestaurantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_TipoQuarto_TiposQuartoId",
                table: "Hotel_TipoQuarto",
                column: "TiposQuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParteViagem_AtracaoTuristica_atracoesVisitadasId",
                table: "ParteViagem_AtracaoTuristica",
                column: "atracoesVisitadasId");

            migrationBuilder.CreateIndex(
                name: "IX_ParteViagem_Restaurante_restaurantesVisitadosId",
                table: "ParteViagem_Restaurante",
                column: "restaurantesVisitadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtracoesTuristicas_Locais_LocalId",
                table: "AtracoesTuristicas",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_Locais_LocalId",
                table: "Destinos",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteis_Locais_LocalId",
                table: "Hoteis",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_Viagens_IdViagem",
                table: "PartesViagem",
                column: "IdViagem",
                principalTable: "Viagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantes_TipoCozinha_TipoCozinhaId",
                table: "Restaurantes",
                column: "TipoCozinhaId",
                principalTable: "TipoCozinha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Usuarios_UsuarioId",
                table: "Viagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtracoesTuristicas_Locais_LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_Locais_LocalId",
                table: "Destinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteis_Locais_LocalId",
                table: "Hoteis");

            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Viagens_IdViagem",
                table: "PartesViagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurantes_TipoCozinha_TipoCozinhaId",
                table: "Restaurantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Usuarios_UsuarioId",
                table: "Viagens");

            migrationBuilder.DropTable(
                name: "Destino_AtracaoTuristica");

            migrationBuilder.DropTable(
                name: "Destino_Hotel");

            migrationBuilder.DropTable(
                name: "Destino_Restaurante");

            migrationBuilder.DropTable(
                name: "Hotel_TipoQuarto");

            migrationBuilder.DropTable(
                name: "ParteViagem_AtracaoTuristica");

            migrationBuilder.DropTable(
                name: "ParteViagem_Restaurante");

            migrationBuilder.DropTable(
                name: "TipoCozinha");

            migrationBuilder.DropIndex(
                name: "IX_Restaurantes_LocalId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurantes_TipoCozinhaId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_IdViagem",
                table: "PartesViagem");

            migrationBuilder.DropIndex(
                name: "IX_Hoteis_LocalId",
                table: "Hoteis");

            migrationBuilder.DropIndex(
                name: "IX_AtracoesTuristicas_LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.RenameColumn(
                name: "TipoCozinhaId",
                table: "Restaurantes",
                newName: "TipoCozinha");

            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "Destinos",
                newName: "localId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinos_LocalId",
                table: "Destinos",
                newName: "IX_Destinos_localId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Viagens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "TipoQuarto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinoId",
                table: "Restaurantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParteViagemId",
                table: "Restaurantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViagemId",
                table: "PartesViagem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinoId",
                table: "Hoteis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinoId",
                table: "AtracoesTuristicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParteViagemId",
                table: "AtracoesTuristicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoQuarto_HotelId",
                table: "TipoQuarto",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_DestinoId",
                table: "Restaurantes",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_LocalId",
                table: "Restaurantes",
                column: "LocalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_ParteViagemId",
                table: "Restaurantes",
                column: "ParteViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_ViagemId",
                table: "PartesViagem",
                column: "ViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteis_DestinoId",
                table: "Hoteis",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteis_LocalId",
                table: "Hoteis",
                column: "LocalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtracoesTuristicas_DestinoId",
                table: "AtracoesTuristicas",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtracoesTuristicas_LocalId",
                table: "AtracoesTuristicas",
                column: "LocalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtracoesTuristicas_ParteViagemId",
                table: "AtracoesTuristicas",
                column: "ParteViagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtracoesTuristicas_Destinos_DestinoId",
                table: "AtracoesTuristicas",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtracoesTuristicas_Locais_LocalId",
                table: "AtracoesTuristicas",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtracoesTuristicas_PartesViagem_ParteViagemId",
                table: "AtracoesTuristicas",
                column: "ParteViagemId",
                principalTable: "PartesViagem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_Locais_localId",
                table: "Destinos",
                column: "localId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteis_Destinos_DestinoId",
                table: "Hoteis",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteis_Locais_LocalId",
                table: "Hoteis",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_Viagens_ViagemId",
                table: "PartesViagem",
                column: "ViagemId",
                principalTable: "Viagens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantes_Destinos_DestinoId",
                table: "Restaurantes",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantes_PartesViagem_ParteViagemId",
                table: "Restaurantes",
                column: "ParteViagemId",
                principalTable: "PartesViagem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoQuarto_Hoteis_HotelId",
                table: "TipoQuarto",
                column: "HotelId",
                principalTable: "Hoteis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Usuarios_UsuarioId",
                table: "Viagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
