using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Destinos_DestinoId",
                table: "PartesViagem");

            migrationBuilder.RenameColumn(
                name: "DestinoId",
                table: "PartesViagem",
                newName: "restaurantesVisitadosId");

            migrationBuilder.RenameColumn(
                name: "DataInical",
                table: "PartesViagem",
                newName: "DataInicial");

            migrationBuilder.RenameIndex(
                name: "IX_PartesViagem_DestinoId",
                table: "PartesViagem",
                newName: "IX_PartesViagem_restaurantesVisitadosId");

            migrationBuilder.AddColumn<float>(
                name: "valorMedio",
                table: "Restaurantes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "PartesViagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "atracoesVisitadasId",
                table: "PartesViagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ValorIngresso",
                table: "AtracoesTuristicas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoQuarto_Hoteis_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_atracoesVisitadasId",
                table: "PartesViagem",
                column: "atracoesVisitadasId");

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_HotelId",
                table: "PartesViagem",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoQuarto_HotelId",
                table: "TipoQuarto",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_AtracoesTuristicas_atracoesVisitadasId",
                table: "PartesViagem",
                column: "atracoesVisitadasId",
                principalTable: "AtracoesTuristicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_Hoteis_HotelId",
                table: "PartesViagem",
                column: "HotelId",
                principalTable: "Hoteis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_Restaurantes_restaurantesVisitadosId",
                table: "PartesViagem",
                column: "restaurantesVisitadosId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_AtracoesTuristicas_atracoesVisitadasId",
                table: "PartesViagem");

            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Hoteis_HotelId",
                table: "PartesViagem");

            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Restaurantes_restaurantesVisitadosId",
                table: "PartesViagem");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_atracoesVisitadasId",
                table: "PartesViagem");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_HotelId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "valorMedio",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "atracoesVisitadasId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "ValorIngresso",
                table: "AtracoesTuristicas");

            migrationBuilder.RenameColumn(
                name: "restaurantesVisitadosId",
                table: "PartesViagem",
                newName: "DestinoId");

            migrationBuilder.RenameColumn(
                name: "DataInicial",
                table: "PartesViagem",
                newName: "DataInical");

            migrationBuilder.RenameIndex(
                name: "IX_PartesViagem_restaurantesVisitadosId",
                table: "PartesViagem",
                newName: "IX_PartesViagem_DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_Destinos_DestinoId",
                table: "PartesViagem",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
