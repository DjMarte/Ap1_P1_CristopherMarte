using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ap1_P1_CristopherMarte.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoExistenciaalProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Existencia",
                table: "Articulos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "Articulos");
        }
    }
}
