﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RutasCheck.Data;

namespace RutasCheck.Migrations
{
    [DbContext(typeof(RutasCheckContext))]
    [Migration("20200424022057_add_concecionarios")]
    partial class add_concecionarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RutasCheck.Models.Carrera", b =>
                {
                    b.Property<long>("IdCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("IdChofer")
                        .HasColumnType("int");

                    b.Property<int>("IdDetalleRuta")
                        .HasColumnType("int");

                    b.Property<int>("IdUnidad")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdCarrera")
                        .HasName("PRIMARY");

                    b.HasIndex("IdDetalleRuta")
                        .HasName("Id_Detalle_Ruta1_FK_idx");

                    b.HasIndex("IdUnidad")
                        .HasName("Id_Unidades_FK_idx");

                    b.ToTable("carreras");
                });

            modelBuilder.Entity("RutasCheck.Models.Concecionario", b =>
                {
                    b.Property<int>("IdConcecionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdConcecionario");

                    b.ToTable("Concecionarios");
                });

            modelBuilder.Entity("RutasCheck.Models.DetalleRuta", b =>
                {
                    b.Property<int>("IdDetalleRuta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<int>("IdRuta")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleRuta")
                        .HasName("PRIMARY");

                    b.HasIndex("IdRuta")
                        .HasName("Id_Ruta_FK_idx");

                    b.ToTable("detalles_ruta");
                });

            modelBuilder.Entity("RutasCheck.Models.ParadaDetalleRuta", b =>
                {
                    b.Property<long>("IdParada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("IdDetalleRuta")
                        .HasColumnType("int");

                    b.Property<long?>("IdParadaOrigen")
                        .HasColumnType("bigint");

                    b.Property<string>("Parada")
                        .HasColumnType("varchar(120)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<TimeSpan>("TiempoEstimado")
                        .HasColumnType("time");

                    b.HasKey("IdParada")
                        .HasName("PRIMARY");

                    b.HasIndex("IdDetalleRuta")
                        .HasName("Id_Detalle_Ruta_FK_idx");

                    b.HasIndex("IdParadaOrigen")
                        .HasName("Id_Parada_Orgigen_idx");

                    b.ToTable("paradas_detalles_ruta");
                });

            modelBuilder.Entity("RutasCheck.Models.Recorrido", b =>
                {
                    b.Property<long>("IdRecorrido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<TimeSpan?>("HoraSalida")
                        .HasColumnType("time");

                    b.Property<long?>("IdCarrera")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdParada")
                        .HasColumnType("bigint");

                    b.HasKey("IdRecorrido")
                        .HasName("PRIMARY");

                    b.HasIndex("IdCarrera")
                        .HasName("Id_Carrera_FK_idx");

                    b.HasIndex("IdParada")
                        .HasName("Id_Parada_FK_idx");

                    b.ToTable("recorridos");
                });

            modelBuilder.Entity("RutasCheck.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDelte")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("IdRol")
                        .HasName("PRIMARY");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            IdRol = 1,
                            IsDelte = false,
                            Nombre = "Administrador"
                        });
                });

            modelBuilder.Entity("RutasCheck.Models.Ruta", b =>
                {
                    b.Property<int>("IdRuta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("varchar(45)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(45)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("IdRuta")
                        .HasName("PRIMARY");

                    b.ToTable("rutas");
                });

            modelBuilder.Entity("RutasCheck.Models.Unidad", b =>
                {
                    b.Property<int>("IdUnidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdConcecionario")
                        .HasColumnType("int");

                    b.Property<int>("IdPropiedatrio")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NumeroEconomico")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdUnidad")
                        .HasName("PRIMARY");

                    b.HasIndex("IdConcecionario")
                        .HasName("Id_Concencionario_FK_idx");

                    b.HasIndex("IdPropiedatrio")
                        .HasName("Id_Porpietario_FK_idx");

                    b.HasIndex("NumeroEconomico")
                        .IsUnique()
                        .HasName("Numero_Economico_UNIQUE");

                    b.ToTable("unidades");
                });

            modelBuilder.Entity("RutasCheck.Models.Usuario", b =>
                {
                    b.Property<long>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idUsuario")
                        .HasColumnType("bigint");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("IdRuta")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(125)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(45)")
                        .HasAnnotation("MySql:CharSet", "utf8")
                        .HasAnnotation("MySql:Collation", "utf8_general_ci");

                    b.HasKey("IdUsuario")
                        .HasName("PRIMARY");

                    b.HasIndex("IdRuta")
                        .HasName("Id_Ruta_Usuario_FK_idx");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasName("UserName_UNIQUE");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1L,
                            Activo = true,
                            IsDelete = false,
                            Nombre = "Admin",
                            Password = "p0a1qmJdN+Xwn0W/vhNJRIvfFu0AWDTqDbTdN/JKTMw=",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("RutasCheck.Models.UsuarioHasRol", b =>
                {
                    b.Property<long>("IdUsuario")
                        .HasColumnName("Id_Usuario")
                        .HasColumnType("bigint");

                    b.Property<int>("IdRol")
                        .HasColumnName("Id_Rol")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario", "IdRol")
                        .HasName("PRIMARY");

                    b.HasIndex("IdRol")
                        .HasName("fk_Usuarios_has_Roles_Roles1_idx");

                    b.HasIndex("IdUsuario")
                        .HasName("fk_Usuarios_has_Roles_Usuarios1_idx");

                    b.ToTable("usuarios_has_roles");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1L,
                            IdRol = 1
                        });
                });

            modelBuilder.Entity("RutasCheck.Models.Carrera", b =>
                {
                    b.HasOne("RutasCheck.Models.DetalleRuta", "IdDetalleRutaNavigation")
                        .WithMany("Carreras")
                        .HasForeignKey("IdDetalleRuta")
                        .HasConstraintName("Id_Detalle_Ruta1_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RutasCheck.Models.Unidad", "IdUnidadNavigation")
                        .WithMany("Carreras")
                        .HasForeignKey("IdUnidad")
                        .HasConstraintName("Id_Unidades_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RutasCheck.Models.DetalleRuta", b =>
                {
                    b.HasOne("RutasCheck.Models.Ruta", "IdRutaNavigation")
                        .WithMany("DetallesRutas")
                        .HasForeignKey("IdRuta")
                        .HasConstraintName("Id_Ruta1_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RutasCheck.Models.ParadaDetalleRuta", b =>
                {
                    b.HasOne("RutasCheck.Models.DetalleRuta", "IdDetalleRutaNavigation")
                        .WithMany("ParadaDetallesRuta")
                        .HasForeignKey("IdDetalleRuta")
                        .HasConstraintName("Id_Detalle_Ruta_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RutasCheck.Models.ParadaDetalleRuta", "IdParadaOrigenNavigation")
                        .WithMany("InverseIdParadaOrigenNavigation")
                        .HasForeignKey("IdParadaOrigen")
                        .HasConstraintName("Id_Parada_Orgigen");
                });

            modelBuilder.Entity("RutasCheck.Models.Recorrido", b =>
                {
                    b.HasOne("RutasCheck.Models.Carrera", "IdCarreraNavigation")
                        .WithMany("Recorridos")
                        .HasForeignKey("IdCarrera")
                        .HasConstraintName("Id_Carrera_FK");

                    b.HasOne("RutasCheck.Models.ParadaDetalleRuta", "IdParadaNavigation")
                        .WithMany("Recorridos")
                        .HasForeignKey("IdParada")
                        .HasConstraintName("Id_Parada_FK");
                });

            modelBuilder.Entity("RutasCheck.Models.Unidad", b =>
                {
                    b.HasOne("RutasCheck.Models.Concecionario", "IdConcecionarioNavigation")
                        .WithMany("UnidadesConcecionarios")
                        .HasForeignKey("IdConcecionario")
                        .HasConstraintName("Id_Concecionario_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RutasCheck.Models.Concecionario", "IdPropietarioNavigation")
                        .WithMany("UnidadesPropietarios")
                        .HasForeignKey("IdPropiedatrio")
                        .HasConstraintName("Id_Propiedatrio_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RutasCheck.Models.Usuario", b =>
                {
                    b.HasOne("RutasCheck.Models.Ruta", "IdRutaNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRuta")
                        .HasConstraintName("Id_Ruta_Usuario_FK");
                });

            modelBuilder.Entity("RutasCheck.Models.UsuarioHasRol", b =>
                {
                    b.HasOne("RutasCheck.Models.Rol", "RolesIdRolNavigation")
                        .WithMany("UsuariosHasRoles")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("fk_Usuarios_has_Roles_Roles1")
                        .IsRequired();

                    b.HasOne("RutasCheck.Models.Usuario", "UsuariosIdUsuarioNavigation")
                        .WithMany("UsuariosHasRoles")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("fk_Usuarios_has_Roles_Usuarios1")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}