using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class usuarios_requiered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "usuarios",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "usuarios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "usuarios",
                type: "varchar(125)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(125)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:Collation", "utf8_general_ci");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "usuarios",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)")
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "usuarios",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:Collation", "utf8_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "usuarios",
                type: "varchar(125)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(125)")
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("MySql:Collation", "utf8_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:Collation", "utf8_general_ci");

           
        }
    }
}
