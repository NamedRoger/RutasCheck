using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class change_type_isDelte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "unidades",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "rutas",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldNullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "IsDelete",
                table: "unidades",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<sbyte>(
                name: "IsDelete",
                table: "rutas",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(bool));

        }
    }
}
