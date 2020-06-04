using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class removeseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "IdRol",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "IdRol",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "usuarios_has_roles",
                keyColumns: new[] { "Id_Usuario", "Id_Rol" },
                keyValues: new object[] { 1L, 1 });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "IdRol",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "idUsuario",
                keyValue: 1L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "IdRol", "IsDelte", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Administrador" },
                    { 2, false, "Checador Base" },
                    { 3, false, "Checador Parada" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "idUsuario", "Activo", "IdRuta", "IsDelete", "Nombre", "Password", "UserName", "UserNameLowered" },
                values: new object[] { 1L, true, null, false, "Admin", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "usuarios_has_roles",
                columns: new[] { "Id_Usuario", "Id_Rol" },
                values: new object[] { 1L, 1 });
        }
    }
}
