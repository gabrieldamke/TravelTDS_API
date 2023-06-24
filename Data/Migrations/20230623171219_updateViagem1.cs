using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class updateViagem1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_AtracoesTuristicas_atracoesVisitadasId",
                table: "PartesViagem");

            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Restaurantes_restaurantesVisitadosId",
                table: "PartesViagem");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_atracoesVisitadasId",
                table: "PartesViagem");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_restaurantesVisitadosId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "atracoesVisitadasId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "restaurantesVisitadosId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Hoteis");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Orcamento",
                table: "Viagens",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ParteViagemId",
                table: "Restaurantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Hoteis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "AtracoesTuristicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParteViagemId",
                table: "AtracoesTuristicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_ParteViagemId",
                table: "Restaurantes",
                column: "ParteViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteis_LocalId",
                table: "Hoteis",
                column: "LocalId",
                unique: true);

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
                name: "FK_Hoteis_Locais_LocalId",
                table: "Hoteis",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantes_PartesViagem_ParteViagemId",
                table: "Restaurantes",
                column: "ParteViagemId",
                principalTable: "PartesViagem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtracoesTuristicas_Locais_LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtracoesTuristicas_PartesViagem_ParteViagemId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteis_Locais_LocalId",
                table: "Hoteis");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurantes_PartesViagem_ParteViagemId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_Restaurantes_ParteViagemId",
                table: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_Hoteis_LocalId",
                table: "Hoteis");

            migrationBuilder.DropIndex(
                name: "IX_AtracoesTuristicas_LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropIndex(
                name: "IX_AtracoesTuristicas_ParteViagemId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "Orcamento",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "ParteViagemId",
                table: "Restaurantes");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Hoteis");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "AtracoesTuristicas");

            migrationBuilder.DropColumn(
                name: "ParteViagemId",
                table: "AtracoesTuristicas");

            migrationBuilder.AddColumn<int>(
                name: "atracoesVisitadasId",
                table: "PartesViagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "restaurantesVisitadosId",
                table: "PartesViagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Hoteis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_atracoesVisitadasId",
                table: "PartesViagem",
                column: "atracoesVisitadasId");

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_restaurantesVisitadosId",
                table: "PartesViagem",
                column: "restaurantesVisitadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_AtracoesTuristicas_atracoesVisitadasId",
                table: "PartesViagem",
                column: "atracoesVisitadasId",
                principalTable: "AtracoesTuristicas",
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
    }
}
