using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstacionamento.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioChegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
