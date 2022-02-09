using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Frontend.Models
{
    public partial class FidelitasContext : DbContext
    {
        public FidelitasContext()
        {
        }

        public FidelitasContext(DbContextOptions<FidelitasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Pies13> Pies13s { get; set; } = null!;
        public virtual DbSet<Py> Pies { get; set; } = null!;
        public virtual DbSet<Universidad> Universidads { get; set; } = null!;
        public virtual DbSet<Vuelo> Vuelos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8N344E8;Database=Fidelitas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("Carrera");

                entity.Property(e => e.Creacion).HasColumnType("datetime");

                entity.Property(e => e.Decano)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GradoAcademico)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitoGraduacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdUniversidad)
                    .HasConstraintName("FK_Carrera_Universidad");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Pies13>(entity =>
            {
                entity.ToTable("Pies13");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageThumbnailUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LongDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Py>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.ToTable("Universidad");

                entity.Property(e => e.Dominio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fundacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__Vuelo__DC512D92FF431A39");

                entity.ToTable("Vuelo");

                entity.Property(e => e.IId).HasColumnName("iId");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DPesoMaximoMaletas)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("dPesoMaximoMaletas");

                entity.Property(e => e.DValoracionUsuarios)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("dValoracionUsuarios");

                entity.Property(e => e.DtDestinoViaje)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDestinoViaje");

                entity.Property(e => e.DtHoraLlegada)
                    .HasColumnType("datetime")
                    .HasColumnName("dtHoraLlegada");

                entity.Property(e => e.DtHoraSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("dtHoraSalida");

                entity.Property(e => e.DtSalidadViaje)
                    .HasColumnType("datetime")
                    .HasColumnName("dtSalidadViaje");

                entity.Property(e => e.ICantidadPasajeros).HasColumnName("iCantidadPasajeros");

                entity.Property(e => e.IFeedback).HasColumnName("iFeedback");

                entity.Property(e => e.ITipoPasajero).HasColumnName("iTipoPasajero");

                entity.Property(e => e.NNombreAvion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("nNombreAvion");

                entity.Property(e => e.VAerolinea)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vAerolinea");

                entity.HasOne(d => d.IFeedbackNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IFeedback)
                    .HasConstraintName("FK_Vuelo_Feedbacks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
