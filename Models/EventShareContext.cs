using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PROJETO.Models
{
    public partial class EventShareContext : DbContext
    {
        public EventShareContext()
        {
        }

        public EventShareContext(DbContextOptions<EventShareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventoCategoriaTbl> EventoCategoriaTbl { get; set; }
        public virtual DbSet<EventoEspacoTbl> EventoEspacoTbl { get; set; }
        public virtual DbSet<EventoStatusTbl> EventoStatusTbl { get; set; }
        public virtual DbSet<EventoTbl> EventoTbl { get; set; }
        public virtual DbSet<UsuarioTbl> UsuarioTbl { get; set; }
        public virtual DbSet<UsuarioTipoTbl> UsuarioTipoTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EventShare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventoCategoriaTbl>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__evento_c__DB875A4F697C8274");

                entity.Property(e => e.CategoriaNome).IsUnicode(false);
            });

            modelBuilder.Entity<EventoEspacoTbl>(entity =>
            {
                entity.HasKey(e => e.EspacoId)
                    .HasName("PK__evento_e__01BC60947106F283");

                entity.Property(e => e.EspacoNome).IsUnicode(false);
            });

            modelBuilder.Entity<EventoStatusTbl>(entity =>
            {
                entity.HasKey(e => e.EventoStatusId)
                    .HasName("PK__evento_s__F2753B7085C010CE");

                entity.Property(e => e.EventoStatusNome).IsUnicode(false);
            });

            modelBuilder.Entity<EventoTbl>(entity =>
            {
                entity.HasKey(e => e.EventoId)
                    .HasName("PK__evento_t__1850C3AD384CEFB4");

                entity.Property(e => e.EventoHorarioComeco).IsUnicode(false);

                entity.Property(e => e.EventoHorarioFim).IsUnicode(false);

                // entity.Property(e => e.EventoImagem).IsUnicode(false);

                entity.Property(e => e.EventoLinkInscricao).IsUnicode(false);

                entity.Property(e => e.EventoNome).IsUnicode(false);

                entity.HasOne(d => d.CriadorUsuario)
                    .WithMany(p => p.EventoTbl)
                    .HasForeignKey(d => d.CriadorUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__evento_tb__criad__45F365D3");

                entity.HasOne(d => d.EventoCategoria)
                    .WithMany(p => p.EventoTbl)
                    .HasForeignKey(d => d.EventoCategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__evento_tb__event__4316F928");

                entity.HasOne(d => d.EventoEspaco)
                    .WithMany(p => p.EventoTbl)
                    .HasForeignKey(d => d.EventoEspacoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__evento_tb__event__440B1D61");

                entity.HasOne(d => d.EventoStatus)
                    .WithMany(p => p.EventoTbl)
                    .HasForeignKey(d => d.EventoStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__evento_tb__event__44FF419A");
            });

            modelBuilder.Entity<UsuarioTbl>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK__usuario___2ED7D2AF7CDB8232");

                entity.Property(e => e.UsuarioComunidade).IsUnicode(false);

                entity.Property(e => e.UsuarioEmail).IsUnicode(false);

                entity.Property(e => e.UsuarioImagem).IsUnicode(false);

                entity.Property(e => e.UsuarioNome).IsUnicode(false);

                entity.Property(e => e.UsuarioSenha).IsUnicode(false);

                entity.HasOne(d => d.UsuarioTipo)
                    .WithMany(p => p.UsuarioTbl)
                    .HasForeignKey(d => d.UsuarioTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_t__usuar__403A8C7D");
            });

            modelBuilder.Entity<UsuarioTipoTbl>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK__usuario___6EA5A01BD0A27AE4");

                entity.Property(e => e.TipoNome).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
