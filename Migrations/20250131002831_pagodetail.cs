using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechLottery.Migrations
{
    /// <inheritdoc />
    public partial class pagodetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Sorteos_SorteoId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_SorteoId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "SorteoId",
                table: "Pagos");

            migrationBuilder.CreateTable(
                name: "PagoDetalles",
                columns: table => new
                {
                    PagoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagoId = table.Column<int>(type: "int", nullable: false),
                    SorteoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoDetalles", x => x.PagoDetalleId);
                    table.ForeignKey(
                        name: "FK_PagoDetalles_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoDetalles_Sorteos_SorteoId",
                        column: x => x.SorteoId,
                        principalTable: "Sorteos",
                        principalColumn: "SorteoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_PagoId",
                table: "PagoDetalles",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_SorteoId",
                table: "PagoDetalles",
                column: "SorteoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagoDetalles");

            migrationBuilder.AddColumn<int>(
                name: "SorteoId",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_SorteoId",
                table: "Pagos",
                column: "SorteoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Sorteos_SorteoId",
                table: "Pagos",
                column: "SorteoId",
                principalTable: "Sorteos",
                principalColumn: "SorteoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
