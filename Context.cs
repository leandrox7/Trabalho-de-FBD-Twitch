using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Twitch.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public  DbSet<CanalStreamer> CanalStreamer { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<DadosPagamento> DadosPagamento { get; set; }
        public virtual DbSet<Gravacao> Gravacao { get; set; }
        public virtual DbSet<Inscritos> Inscritos { get; set; }
        public virtual DbSet<Recomendacoes> Recomendacoes { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=leandro;password=leandrox7;database=Twitch", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanalStreamer>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Online).HasColumnName("online_");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.Nome)
                    .HasName("PRIMARY");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<DadosPagamento>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("cod_usuario");

                entity.Property(e => e.Cpf).HasColumnName("cpf");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NroCartao).HasColumnName("nro_cartao");

                entity.Property(e => e.Telefone).HasColumnName("telefone");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.DadosPagamento)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("DadosPagamento_ibfk_1");
            });

            modelBuilder.Entity<Gravacao>(entity =>
            {
                entity.HasKey(e => e.CodTransmissao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CodStreamer)
                    .HasName("cod_streamer");

                entity.Property(e => e.CodTransmissao).HasColumnName("cod_transmissao");

                entity.Property(e => e.CodStreamer).HasColumnName("cod_streamer");

                entity.Property(e => e.Duracao)
                    .HasColumnName("duracao")
                    .HasColumnType("time");

                entity.Property(e => e.MaxEspectadores).HasColumnName("max_espectadores");

                entity.Property(e => e.TotalVisualizacoes).HasColumnName("total_visualizacoes");

                entity.HasOne(d => d.CodStreamerNavigation)
                    .WithMany(p => p.Gravacao)
                    .HasForeignKey(d => d.CodStreamer)
                    .HasConstraintName("Gravacao_ibfk_1");
            });

            modelBuilder.Entity<Inscritos>(entity =>
            {
                entity.HasKey(e => new { e.CodUsuario, e.CodCanal })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CodCanal)
                    .HasName("cod_canal");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.CodCanal).HasColumnName("cod_canal");

                entity.Property(e => e.DataFim)
                    .HasColumnName("data_fim")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("data_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.TotalMeses).HasColumnName("total_meses");

                entity.HasOne(d => d.CodCanalNavigation)
                    .WithMany(p => p.InscritosCodCanalNavigation)
                    .HasForeignKey(d => d.CodCanal)
                    .HasConstraintName("Inscritos_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.InscritosCodUsuarioNavigation)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Inscritos_ibfk_1");
            });

            modelBuilder.Entity<Recomendacoes>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdCanal })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCanal)
                    .HasName("id_canal");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdCanal).HasColumnName("id_canal");

                entity.HasOne(d => d.IdCanalNavigation)
                    .WithMany(p => p.RecomendacoesIdCanalNavigation)
                    .HasForeignKey(d => d.IdCanal)
                    .HasConstraintName("Recomendacoes_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RecomendacoesIdUsuarioNavigation)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("Recomendacoes_ibfk_1");
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => new { e.CodUsuario, e.CodCanal })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CodCanal)
                    .HasName("cod_canal");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.CodCanal).HasColumnName("cod_canal");

                entity.Property(e => e.Meses).HasColumnName("meses");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.CodCanalNavigation)
                    .WithMany(p => p.TransacaoCodCanalNavigation)
                    .HasForeignKey(d => d.CodCanal)
                    .HasConstraintName("Transacao_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.TransacaoCodUsuarioNavigation)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("Transacao_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
