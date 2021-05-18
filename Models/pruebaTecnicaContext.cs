using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTecnicaVivianaLargo.Models
{
    public partial class pruebaTecnicaContext : DbContext
    {
        public pruebaTecnicaContext()
        {
        }

        public pruebaTecnicaContext(DbContextOptions<pruebaTecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Comercios> Comercios { get; set; }
        public virtual DbSet<Pagadores> Pagadores { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-IANU77J\\SQLEXPRESS;database=pruebaTecnica;Trusted_Connection = True");
                //optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=DESKTOP-IANU77J\\SQLEXPRESS;database=pruebaTecnica;User Id=pruebaTecnica; Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");



                entity.Property(e => e.IdComercio).HasColumnName("idComercio");

                entity.Property(e => e.IdPagador).HasColumnName("idPagador");

                entity.Property(e => e.IdTransaccion).HasColumnName("idTransaccion");

                entity.HasOne(d => d.IdComercioNavigation)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.IdComercio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balance_Comercios");

                entity.HasOne(d => d.IdPagadorNavigation)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.IdPagador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balance_Pagadores");

                entity.HasOne(d => d.IdTransaccionNavigation)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.IdTransaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balance_Transacciones");
            });

            modelBuilder.Entity<Comercios>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_Comercios")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasColumnName("nit")
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Comercios)
                    .HasForeignKey<Comercios>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comercios_Usuarios");
            });

            modelBuilder.Entity<Pagadores>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasColumnName("identificacion")
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagadores)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagadores_Pagadores");
            });

            modelBuilder.Entity<Transacciones>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_Transacciones")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasColumnName("concepto")
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.MedioPago).HasColumnName("medioPago");

                entity.Property(e => e.Monto).HasColumnName("monto");
                                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasColumnName("contrasenia")
                    .IsUnicode(false);

                entity.Property(e => e.TipoPerfil).HasColumnName("tipoPerfil");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
