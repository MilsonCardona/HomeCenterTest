using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCenterTest.Infrastructure.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoIdentificacion",
                newName: "IdTipoIdentificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTipoIdentificacion",
                table: "TipoIdentificacion",
                newName: "Id");
        }
    }
}
