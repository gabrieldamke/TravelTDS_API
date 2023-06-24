using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class despesas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DespesasId",
                table: "PartesViagem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustosTransporte = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustosHospedagem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustosAtracoesTuristicas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustosRestaurantes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustosExtras = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartesViagem_DespesasId",
                table: "PartesViagem",
                column: "DespesasId",
                unique: true,
                filter: "[DespesasId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PartesViagem_Despesas_DespesasId",
                table: "PartesViagem",
                column: "DespesasId",
                principalTable: "Despesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartesViagem_Despesas_DespesasId",
                table: "PartesViagem");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_PartesViagem_DespesasId",
                table: "PartesViagem");

            migrationBuilder.DropColumn(
                name: "DespesasId",
                table: "PartesViagem");
        }
    }
}
