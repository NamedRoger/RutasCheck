using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class add_concecionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "unidades");

            migrationBuilder.AddColumn<int>(
                name: "IdConcecionario",
                table: "unidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPropiedatrio",
                table: "unidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NumeroEconomico",
                table: "unidades",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "unidades",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Concecionarios",
                columns: table => new
                {
                    IdConcecionario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concecionarios", x => x.IdConcecionario);
                });

          

            migrationBuilder.CreateIndex(
                name: "Id_Concencionario_FK_idx",
                table: "unidades",
                column: "IdConcecionario");

            migrationBuilder.CreateIndex(
                name: "Id_Porpietario_FK_idx",
                table: "unidades",
                column: "IdPropiedatrio");

            migrationBuilder.CreateIndex(
                name: "Numero_Economico_UNIQUE",
                table: "unidades",
                column: "NumeroEconomico",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Id_Concecionario_FK",
                table: "unidades",
                column: "IdConcecionario",
                principalTable: "Concecionarios",
                principalColumn: "IdConcecionario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Id_Propiedatrio_FK",
                table: "unidades",
                column: "IdPropiedatrio",
                principalTable: "Concecionarios",
                principalColumn: "IdConcecionario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Id_Concecionario_FK",
                table: "unidades");

            migrationBuilder.DropForeignKey(
                name: "Id_Propiedatrio_FK",
                table: "unidades");

            migrationBuilder.DropTable(
                name: "Concecionarios");

            migrationBuilder.DropIndex(
                name: "Id_Concencionario_FK_idx",
                table: "unidades");

            migrationBuilder.DropIndex(
                name: "Id_Porpietario_FK_idx",
                table: "unidades");

            migrationBuilder.DropIndex(
                name: "Numero_Economico_UNIQUE",
                table: "unidades");

            migrationBuilder.DropColumn(
                name: "IdConcecionario",
                table: "unidades");

            migrationBuilder.DropColumn(
                name: "IdPropiedatrio",
                table: "unidades");

            migrationBuilder.DropColumn(
                name: "NumeroEconomico",
                table: "unidades");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "unidades");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "unidades",
                type: "varchar(45)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci");

            
        }
    }
}
