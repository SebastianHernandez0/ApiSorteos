using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechLottery.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var adminId = Guid.NewGuid().ToString();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("admin123");

            migrationBuilder.Sql($@"
            SET IDENTITY_INSERT Usuarios ON;
            INSERT INTO Usuarios (UserId, Nombre, Correo, Password, Rol , FechaRegistro, Instagram ,Telefono)
            VALUES (1, 'Admin', 'admin@admin.com', '{hashedPassword}', 'Admin' , '{DateTime.Now}', 'admin_instagram', 1234567890 )
            SET IDENTITY_INSERT Usuarios OFF;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Usuarios WHERE Correo = 'admin@admin.com'");
        }
    }
}
