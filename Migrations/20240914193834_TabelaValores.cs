using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class TabelaValores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "preco",
                table: "Veiculos",
                newName: "Desconto");

            migrationBuilder.AddColumn<int>(
                name: "ValorId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "valores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicioVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ValorId",
                table: "Veiculos",
                column: "ValorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_valores_ValorId",
                table: "Veiculos",
                column: "ValorId",
                principalTable: "valores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_valores_ValorId",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "valores");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_ValorId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "ValorId",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "Desconto",
                table: "Veiculos",
                newName: "preco");
        }
    }
}
