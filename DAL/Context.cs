using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<BARBEROS> BARBEROS { get; set; }
        public virtual DbSet<CLIENTES> CLIENTES { get; set; }
        public virtual DbSet<ReservaTurno> ReservaTurno { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BARBEROS>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BARBEROS>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<BARBEROS>()
                .Property(e => e.TELEFONO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BARBEROS>()
                .HasMany(e => e.ReservaTurno)
                .WithRequired(e => e.BARBEROS)
                .HasForeignKey(e => e.ID_PELUQUERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.TELEFONO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.CONTRASEÑA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .HasMany(e => e.ReservaTurno)
                .WithOptional(e => e.CLIENTES)
                .HasForeignKey(e => e.ID_CLIENTE);

            modelBuilder.Entity<ReservaTurno>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReservaTurno>()
                .Property(e => e.ID_CLIENTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReservaTurno>()
                .Property(e => e.ID_PELUQUERO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReservaTurno>()
                .Property(e => e.ID_SERVICIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Servicio>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Servicio>()
                .Property(e => e.SERVICIO1)
                .IsUnicode(false);

            modelBuilder.Entity<Servicio>()
                .Property(e => e.PRECIO)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Servicio>()
                .HasMany(e => e.ReservaTurno)
                .WithRequired(e => e.Servicio)
                .HasForeignKey(e => e.ID_SERVICIO)
                .WillCascadeOnDelete(false);
        }
    }
}
