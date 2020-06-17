using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RutasCheck.Helpers;
using RutasCheck.Models;

namespace RutasCheck.Data
{
    public partial class RutasCheckContext : DbContext
    {
        public RutasCheckContext(DbContextOptions<RutasCheckContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<DetalleRuta> DetallesRutas { get; set; }
        public virtual DbSet<ParadaDetalleRuta> ParadasDetallesRutas { get; set; }
        public virtual DbSet<Recorrido> Recorridos { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Ruta> Rutas { get; set; }
        public virtual DbSet<Unidad> Unidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioHasRol> UsuariosHasRoles { get; set; }
        public virtual DbSet<Concecionario> Concecionarios { get; set; }
        public virtual DbSet<Parada> Paradas {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PRIMARY");

                entity.ToTable("carreras");

                entity.HasIndex(e => e.IdDetalleRuta)
                    .HasName("Id_Detalle_Ruta1_FK_idx");

                entity.HasIndex(e => e.IdUnidad)
                    .HasName("Id_Unidades_FK_idx");

                entity.Property(e => e.HoraInicio).HasColumnType("time");

                entity.HasOne(d => d.IdDetalleRutaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdDetalleRuta)
                    .HasConstraintName("Id_Detalle_Ruta1_FK");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdUnidad)
                    .HasConstraintName("Id_Unidades_FK");
            });

            modelBuilder.Entity<DetalleRuta>(entity =>
            {
                entity.HasKey(e => e.IdDetalleRuta)
                    .HasName("PRIMARY");

                entity.ToTable("detalles_ruta");

                entity.HasIndex(e => e.IdRuta)
                    .HasName("Id_Ruta_FK_idx");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.DetallesRutas)
                    .HasForeignKey(d => d.IdRuta)
                    .HasConstraintName("Id_Ruta1_FK");
            });


            modelBuilder.Entity<ParadaDetalleRuta>(entity =>
            {
                entity.HasKey(e => e.IdParadaDetalleRuta)
                    .HasName("PRIMARY");

                entity.ToTable("paradas_detalles_ruta");

                entity.HasIndex(e => e.IdDetalleRuta)
                    .HasName("Id_Detalle_Ruta_FK_idx");

                entity.HasIndex(e => e.IdParadaOrigen)
                    .HasName("Id_Parada_Orgigen_idx");

                entity.Property(e => e.TiempoEstimado).HasColumnType("time");

                entity.HasOne(d => d.IdDetalleRutaNavigation)
                    .WithMany(p => p.ParadaDetallesRuta)
                    .HasForeignKey(d => d.IdDetalleRuta)
                    .HasConstraintName("Id_Detalle_Ruta_FK");

                entity.HasOne(d => d.IdParadaOrigenNavigation)
                    .WithMany(p => p.InverseIdParadaOrigenNavigation)
                    .HasForeignKey(d => d.IdParadaOrigen)
                    .HasConstraintName("Id_Parada_Orgigen");

                entity.HasOne(d => d.Parada)
                .WithMany(p => p.ParadaDetallesRuta)
                .HasForeignKey(d => d.IdParada);
            });

            modelBuilder.Entity<Recorrido>(entity =>
            {
                entity.HasKey(e => e.IdRecorrido)
                    .HasName("PRIMARY");

                entity.ToTable("recorridos");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("Id_Carrera_FK_idx");

                entity.HasIndex(e => e.IdParadaDetalleRuta)
                    .HasName("Id_Parada_FK_idx");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.HoraSalida).HasColumnType("time");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Recorridos)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("Id_Carrera_FK");

                entity.HasOne(d => d.IdParadaNavigation)
                    .WithMany(p => p.Recorridos)
                    .HasForeignKey(d => d.IdParadaDetalleRuta)
                    .HasConstraintName("Id_Parada_FK");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.HasKey(e => e.IdRuta)
                    .HasName("PRIMARY");

                entity.ToTable("rutas");

                entity.Property(e => e.Color)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(e => e.IdUnidad)
                    .HasName("PRIMARY");

                entity.ToTable("unidades");

                entity.HasIndex(e => e.NumeroEconomico)
                .HasName("Numero_Economico_UNIQUE")
                .IsUnique();

                entity.HasIndex(e => e.IdConcecionario)
                    .HasName("Id_Concencionario_FK_idx");

                entity.HasIndex(e => e.IdPropiedatrio)
                    .HasName("Id_Porpietario_FK_idx");

                entity.Property(e => e.NumeroEconomico)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(e => e.Placa)
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                entity.HasOne(d => d.IdConcecionarioNavigation)
                    .WithMany(p => p.UnidadesConcecionarios)
                    .HasForeignKey(d => d.IdConcecionario)
                    .HasConstraintName("Id_Concecionario_FK");

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(d => d.UnidadesPropietarios)
                    .HasForeignKey(d => d.IdPropiedatrio)
                    .HasConstraintName("Id_Propiedatrio_FK");

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdRuta)
                    .HasName("Id_Ruta_Usuario_FK_idx");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserName_UNIQUE")
                    .IsUnique(true);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(125)")
                    .HasCharSet("utf8")
                    .IsRequired()
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .IsRequired()
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .IsRequired()
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRuta)
                    .HasConstraintName("Id_Ruta_Usuario_FK");

            });

            modelBuilder.Entity<UsuarioHasRol>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdRol })
                    .HasName("PRIMARY");

                entity.ToTable("usuarios_has_roles");

                entity.HasIndex(e => e.IdRol)
                    .HasName("fk_Usuarios_has_Roles_Roles1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Usuarios_has_Roles_Usuarios1_idx");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.HasOne(d => d.RolesIdRolNavigation)
                    .WithMany(p => p.UsuariosHasRoles)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuarios_has_Roles_Roles1");

                entity.HasOne(d => d.UsuariosIdUsuarioNavigation)
                    .WithMany(p => p.UsuariosHasRoles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuarios_has_Roles_Usuarios1");
            });


            string password = Hash.GetSha256("admin");
            Usuario admin = new Usuario() { IdUsuario = 1, Nombre = "Admin", UserName = "admin", IdRuta = null, Password = password, UserNameLowered = "admin".ToLower() };

            Rol rolAdmin = new Rol { IdRol = 1, Nombre = "Administrador" };
            UsuarioHasRol usuarioHas = new UsuarioHasRol() { IdUsuario = admin.IdUsuario, IdRol = rolAdmin.IdRol };

            modelBuilder.Entity<Usuario>().HasData(admin);

            modelBuilder.Entity<Rol>().HasData(
                rolAdmin,
                new Rol { IdRol = 2, Nombre = "Checador Base" },
                new Rol { IdRol = 3, Nombre = "Checador Parada" });



            modelBuilder.Entity<UsuarioHasRol>().HasData(usuarioHas);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
