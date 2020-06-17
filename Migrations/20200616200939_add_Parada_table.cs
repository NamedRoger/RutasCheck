using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class add_Parada_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parada",
                table: "paradas_detalles_ruta");

            migrationBuilder.AddColumn<int>(
                name: "IdParada",
                table: "paradas_detalles_ruta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paradas",
                columns: table => new
                {
                    IdParada = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreParada = table.Column<string>(nullable: true),
                    NombreNormalizado = table.Column<string>(nullable: true),
                    Borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paradas", x => x.IdParada);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paradas_detalles_ruta_IdParada",
                table: "paradas_detalles_ruta",
                column: "IdParada");

            migrationBuilder.AddForeignKey(
                name: "FK_paradas_detalles_ruta_Paradas_IdParada",
                table: "paradas_detalles_ruta",
                column: "IdParada",
                principalTable: "Paradas",
                principalColumn: "IdParada",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paradas_detalles_ruta_Paradas_IdParada",
                table: "paradas_detalles_ruta");

            migrationBuilder.DropTable(
                name: "Paradas");

            migrationBuilder.DropIndex(
                name: "IX_paradas_detalles_ruta_IdParada",
                table: "paradas_detalles_ruta");

            migrationBuilder.DropColumn(
                name: "IdParada",
                table: "paradas_detalles_ruta");

            migrationBuilder.AddColumn<string>(
                name: "Parada",
                table: "paradas_detalles_ruta",
                type: "varchar(120)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci");
        }
    }
}
