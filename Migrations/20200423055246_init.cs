using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasCheck.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    IsDelte = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    IdRuta = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Color = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    IsDelete = table.Column<sbyte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdRuta);
                });

            migrationBuilder.CreateTable(
                name: "unidades",
                columns: table => new
                {
                    IdUnidad = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    IsDelete = table.Column<sbyte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdUnidad);
                });

            migrationBuilder.CreateTable(
                name: "detalles_ruta",
                columns: table => new
                {
                    IdDetalleRuta = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRuta = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdDetalleRuta);
                    table.ForeignKey(
                        name: "Id_Ruta1_FK",
                        column: x => x.IdRuta,
                        principalTable: "rutas",
                        principalColumn: "IdRuta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(125)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    UserName = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Password = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    IdRuta = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUsuario);
                    table.ForeignKey(
                        name: "Id_Ruta_Usuario_FK",
                        column: x => x.IdRuta,
                        principalTable: "rutas",
                        principalColumn: "IdRuta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    IdCarrera = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdChofer = table.Column<int>(nullable: false),
                    IdDetalleRuta = table.Column<int>(nullable: false),
                    IdUnidad = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdCarrera);
                    table.ForeignKey(
                        name: "Id_Detalle_Ruta1_FK",
                        column: x => x.IdDetalleRuta,
                        principalTable: "detalles_ruta",
                        principalColumn: "IdDetalleRuta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Id_Unidades_FK",
                        column: x => x.IdUnidad,
                        principalTable: "unidades",
                        principalColumn: "IdUnidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paradas_detalles_ruta",
                columns: table => new
                {
                    IdParada = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdDetalleRuta = table.Column<int>(nullable: false),
                    Parada = table.Column<string>(type: "varchar(120)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    TiempoEstimado = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdParadaOrigen = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdParada);
                    table.ForeignKey(
                        name: "Id_Detalle_Ruta_FK",
                        column: x => x.IdDetalleRuta,
                        principalTable: "detalles_ruta",
                        principalColumn: "IdDetalleRuta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Id_Parada_Orgigen",
                        column: x => x.IdParadaOrigen,
                        principalTable: "paradas_detalles_ruta",
                        principalColumn: "IdParada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_has_roles",
                columns: table => new
                {
                    Id_Usuario = table.Column<long>(nullable: false),
                    Id_Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Id_Usuario, x.Id_Rol });
                    table.ForeignKey(
                        name: "fk_Usuarios_has_Roles_Roles1",
                        column: x => x.Id_Rol,
                        principalTable: "roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Usuarios_has_Roles_Usuarios1",
                        column: x => x.Id_Usuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recorridos",
                columns: table => new
                {
                    IdRecorrido = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdParada = table.Column<long>(nullable: true),
                    IdCarrera = table.Column<long>(nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoraSalida = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdRecorrido);
                    table.ForeignKey(
                        name: "Id_Carrera_FK",
                        column: x => x.IdCarrera,
                        principalTable: "carreras",
                        principalColumn: "IdCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Id_Parada_FK",
                        column: x => x.IdParada,
                        principalTable: "paradas_detalles_ruta",
                        principalColumn: "IdParada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Id_Detalle_Ruta1_FK_idx",
                table: "carreras",
                column: "IdDetalleRuta");

            migrationBuilder.CreateIndex(
                name: "Id_Unidades_FK_idx",
                table: "carreras",
                column: "IdUnidad");

            migrationBuilder.CreateIndex(
                name: "Id_Ruta_FK_idx",
                table: "detalles_ruta",
                column: "IdRuta");

            migrationBuilder.CreateIndex(
                name: "Id_Detalle_Ruta_FK_idx",
                table: "paradas_detalles_ruta",
                column: "IdDetalleRuta");

            migrationBuilder.CreateIndex(
                name: "Id_Parada_Orgigen_idx",
                table: "paradas_detalles_ruta",
                column: "IdParadaOrigen");

            migrationBuilder.CreateIndex(
                name: "Id_Carrera_FK_idx",
                table: "recorridos",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "Id_Parada_FK_idx",
                table: "recorridos",
                column: "IdParada");

            migrationBuilder.CreateIndex(
                name: "Id_Ruta_Usuario_FK_idx",
                table: "usuarios",
                column: "IdRuta");

            migrationBuilder.CreateIndex(
                name: "UserName_UNIQUE",
                table: "usuarios",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Usuarios_has_Roles_Roles1_idx",
                table: "usuarios_has_roles",
                column: "Id_Rol");

            migrationBuilder.CreateIndex(
                name: "fk_Usuarios_has_Roles_Usuarios1_idx",
                table: "usuarios_has_roles",
                column: "Id_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recorridos");

            migrationBuilder.DropTable(
                name: "usuarios_has_roles");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "paradas_detalles_ruta");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "unidades");

            migrationBuilder.DropTable(
                name: "detalles_ruta");

            migrationBuilder.DropTable(
                name: "rutas");
        }
    }
}
