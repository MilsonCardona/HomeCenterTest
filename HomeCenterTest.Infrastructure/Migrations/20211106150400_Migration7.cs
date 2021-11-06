using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCenterTest.Infrastructure.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "VARCHAR2(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR2(500)", nullable: true),
                    Marca = table.Column<string>(type: "VARCHAR2(100)", nullable: true),
                    ValorActual = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UnidadesInventario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "VARCHAR2(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR2(500)", nullable: true),
                    Marca = table.Column<string>(type: "VARCHAR2(100)", nullable: true),
                    ValorMinimo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorMaximo = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repuesto");

            migrationBuilder.DropTable(
                name: "Servicio");
        }
    }
}
