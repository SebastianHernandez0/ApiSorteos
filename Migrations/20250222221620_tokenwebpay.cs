using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechLottery.Migrations
{
    /// <inheritdoc />
    public partial class tokenwebpay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenWebpay",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenWebpay",
                table: "Pagos");
        }
    }
}
