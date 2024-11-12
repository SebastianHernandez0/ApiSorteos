using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechLottery.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sorteos",
                columns: table => new
                {
                    SorteoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioBoletos = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoletosTotales = table.Column<int>(type: "int", nullable: false),
                    BoletosVendidos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorteos", x => x.SorteoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    BoletoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SorteoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NumeroBoleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.BoletoId);
                    table.ForeignKey(
                        name: "FK_Boletos_Sorteos_SorteoId",
                        column: x => x.SorteoId,
                        principalTable: "Sorteos",
                        principalColumn: "SorteoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialSorteos",
                columns: table => new
                {
                    HistorialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SorteoId = table.Column<int>(type: "int", nullable: false),
                    GanadorId = table.Column<int>(type: "int", nullable: false),
                    FechaGanado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialSorteos", x => x.HistorialId);
                    table.ForeignKey(
                        name: "FK_HistorialSorteos_Sorteos_SorteoId",
                        column: x => x.SorteoId,
                        principalTable: "Sorteos",
                        principalColumn: "SorteoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialSorteos_Usuarios_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Usuarios",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_SorteoId",
                table: "Boletos",
                column: "SorteoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSorteos_GanadorId",
                table: "HistorialSorteos",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSorteos_SorteoId",
                table: "HistorialSorteos",
                column: "SorteoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletos");

            migrationBuilder.DropTable(
                name: "HistorialSorteos");

            migrationBuilder.DropTable(
                name: "Sorteos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
