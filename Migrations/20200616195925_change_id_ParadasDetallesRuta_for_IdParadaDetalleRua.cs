using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class change_id_ParadasDetallesRuta_for_IdParadaDetalleRua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Id_Parada_Orgigen",
                table: "paradas_detalles_ruta");

            migrationBuilder.DropForeignKey(
                name: "Id_Parada_FK",
                table: "recorridos");

            migrationBuilder.DropIndex(
                name: "Id_Parada_FK_idx",
                table: "recorridos");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "paradas_detalles_ruta");

            migrationBuilder.DropColumn(
                name: "IdParada",
                table: "recorridos");

            migrationBuilder.DropColumn(
                name: "IdParada",
                table: "paradas_detalles_ruta");

            migrationBuilder.AddColumn<long>(
                name: "IdParadaDetalleRuta",
                table: "recorridos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdParadaDetalleRuta",
                table: "paradas_detalles_ruta",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "paradas_detalles_ruta",
                column: "IdParadaDetalleRuta");

            migrationBuilder.CreateIndex(
                name: "Id_Parada_FK_idx",
                table: "recorridos",
                column: "IdParadaDetalleRuta");

            migrationBuilder.AddForeignKey(
                name: "Id_Parada_Orgigen",
                table: "paradas_detalles_ruta",
                column: "IdParadaOrigen",
                principalTable: "paradas_detalles_ruta",
                principalColumn: "IdParadaDetalleRuta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Id_Parada_FK",
                table: "recorridos",
                column: "IdParadaDetalleRuta",
                principalTable: "paradas_detalles_ruta",
                principalColumn: "IdParadaDetalleRuta",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Id_Parada_Orgigen",
                table: "paradas_detalles_ruta");

            migrationBuilder.DropForeignKey(
                name: "Id_Parada_FK",
                table: "recorridos");

            migrationBuilder.DropIndex(
                name: "Id_Parada_FK_idx",
                table: "recorridos");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "paradas_detalles_ruta");

            migrationBuilder.DropColumn(
                name: "IdParadaDetalleRuta",
                table: "recorridos");

            migrationBuilder.DropColumn(
                name: "IdParadaDetalleRuta",
                table: "paradas_detalles_ruta");

            migrationBuilder.AddColumn<long>(
                name: "IdParada",
                table: "recorridos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdParada",
                table: "paradas_detalles_ruta",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "paradas_detalles_ruta",
                column: "IdParada");

            migrationBuilder.CreateIndex(
                name: "Id_Parada_FK_idx",
                table: "recorridos",
                column: "IdParada");

            migrationBuilder.AddForeignKey(
                name: "Id_Parada_Orgigen",
                table: "paradas_detalles_ruta",
                column: "IdParadaOrigen",
                principalTable: "paradas_detalles_ruta",
                principalColumn: "IdParada",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Id_Parada_FK",
                table: "recorridos",
                column: "IdParada",
                principalTable: "paradas_detalles_ruta",
                principalColumn: "IdParada",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
