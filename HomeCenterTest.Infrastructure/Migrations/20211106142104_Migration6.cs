using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCenterTest.Infrastructure.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tercero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdTipoIdentificacion = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PrimerNombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Direccion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Telefono = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Celular = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IdTipoIdentificacionNavigationId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Discriminator = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdTercero = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EmailFacturacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DireccionFacturacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IdTerceroNavigationId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tercero_Tercero_IdTerceroNavigationId",
                        column: x => x.IdTerceroNavigationId,
                        principalTable: "Tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tercero_TipoIdentificacion_IdTipoIdentificacionNavigationId",
                        column: x => x.IdTipoIdentificacionNavigationId,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "IdTipoIdentificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_IdTerceroNavigationId",
                table: "Tercero",
                column: "IdTerceroNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_IdTipoIdentificacionNavigationId",
                table: "Tercero",
                column: "IdTipoIdentificacionNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tercero");
        }
    }
}
