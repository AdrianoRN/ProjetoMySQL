using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoMySQL.Models
{
    public partial class BDContexto : DbContext
    {
        public BDContexto()
        {
        }

        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidato> Candidatos { get; set; } = null!;
        public virtual DbSet<Eleitor> Eleitors { get; set; } = null!;
        public virtual DbSet<Votacao> Votacaos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3308;user=root;database=AulaTeste", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.ToTable("candidato");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Partido)
                    .HasMaxLength(10)
                    .HasColumnName("partido");
            });

            modelBuilder.Entity<Eleitor>(entity =>
            {
                entity.ToTable("eleitor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Votacao>(entity =>
            {
                entity.ToTable("votacao");

                entity.HasIndex(e => e.IdCandidato, "idCandidato");

                entity.HasIndex(e => e.IdEleitor, "idEleitor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCandidato).HasColumnName("idCandidato");

                entity.Property(e => e.IdEleitor).HasColumnName("idEleitor");

                entity.Property(e => e.Secao).HasColumnName("secao");

                entity.Property(e => e.Zona).HasColumnName("zona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
