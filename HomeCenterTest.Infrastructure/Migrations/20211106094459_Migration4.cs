using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCenterTest.Infrastructure.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoIdenti",
                table: "TipoIdentificacion",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoIdenti",
                table: "TipoIdentificacion");
        }
    }
}
