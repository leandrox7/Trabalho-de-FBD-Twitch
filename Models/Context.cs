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

        public virtual DbSet<Canalstreamer> Canalstreamer { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Categorizados> Categorizados { get; set; }
        public virtual DbSet<Dadospagamento> Dadospagamento { get; set; }
        public virtual DbSet<Gravacao> Gravacao { get; set; }
        public virtual DbSet<Inscritos> Inscritos { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<Notificacao> Notificacao { get; set; }
        public virtual DbSet<Participacao> Participacao { get; set; }
        public virtual DbSet<Prime> Prime { get; set; }
        public virtual DbSet<Recomendacoes> Recomendacoes { get; set; }
        public virtual DbSet<Recompensa> Recompensa { get; set; }
        public virtual DbSet<Seguir> Seguir { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=Twitch", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canalstreamer>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("canalstreamer");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

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
                entity.HasKey(e => e.CodCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categorias");

                entity.Property(e => e.CodCategoria).HasColumnName("cod_categoria");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Categorizados>(entity =>
            {
                entity.HasKey(e => new { e.CodGravacao, e.CodCategoria })
                    .HasName("PRIMARY");

                entity.ToTable("categorizados");

                entity.HasIndex(e => e.CodCategoria)
                    .HasName("cod_categoria");

                entity.Property(e => e.CodGravacao).HasColumnName("cod_gravacao");

                entity.Property(e => e.CodCategoria).HasColumnName("cod_categoria");

                entity.HasOne(d => d.CodCategoriaNavigation)
                    .WithMany(p => p.Categorizados)
                    .HasForeignKey(d => d.CodCategoria)
                    .HasConstraintName("categorizados_ibfk_2");

                entity.HasOne(d => d.CodGravacaoNavigation)
                    .WithMany(p => p.Categorizados)
                    .HasForeignKey(d => d.CodGravacao)
                    .HasConstraintName("categorizados_ibfk_1");
            });

            modelBuilder.Entity<Dadospagamento>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.ToTable("dadospagamento");

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
                    .WithMany(p => p.Dadospagamento)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("dadospagamento_ibfk_1");
            });

            modelBuilder.Entity<Gravacao>(entity =>
            {
                entity.HasKey(e => e.CodTransmissao)
                    .HasName("PRIMARY");

                entity.ToTable("gravacao");

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
                    .HasConstraintName("gravacao_ibfk_1");
            });

            modelBuilder.Entity<Inscritos>(entity =>
            {
                entity.HasKey(e => new { e.CodUsuario, e.CodCanal })
                    .HasName("PRIMARY");

                entity.ToTable("inscritos");

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
                    .HasConstraintName("inscritos_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.InscritosCodUsuarioNavigation)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("inscritos_ibfk_1");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.CodItem)
                    .HasName("PRIMARY");

                entity.ToTable("items");

                entity.Property(e => e.CodItem).HasColumnName("cod_item");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<Mensagem>(entity =>
            {
                entity.HasKey(e => e.IdMensagem)
                    .HasName("PRIMARY");

                entity.ToTable("mensagem");

                entity.HasIndex(e => e.CodGravacao)
                    .HasName("cod_gravacao");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("cod_usuario");

                entity.Property(e => e.IdMensagem).HasColumnName("id_mensagem");

                entity.Property(e => e.CodGravacao).HasColumnName("cod_gravacao");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.Conteudo)
                    .HasColumnName("conteudo")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CodGravacaoNavigation)
                    .WithMany(p => p.Mensagem)
                    .HasForeignKey(d => d.CodGravacao)
                    .HasConstraintName("mensagem_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Mensagem)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("mensagem_ibfk_1");
            });

            modelBuilder.Entity<Notificacao>(entity =>
            {
                entity.HasKey(e => e.IdNotificacao)
                    .HasName("PRIMARY");

                entity.ToTable("notificacao");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("cod_usuario");

                entity.Property(e => e.IdNotificacao).HasColumnName("id_notificacao");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.Mensagem)
                    .HasColumnName("mensagem")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Notificacao)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("notificacao_ibfk_1");
            });

            modelBuilder.Entity<Participacao>(entity =>
            {
                entity.HasKey(e => new { e.DataParticipacao, e.CodUsuario, e.CodGravacao })
                    .HasName("PRIMARY");

                entity.ToTable("participacao");

                entity.HasIndex(e => e.CodGravacao)
                    .HasName("cod_gravacao");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("cod_usuario");

                entity.Property(e => e.DataParticipacao)
                    .HasColumnName("data_participacao")
                    .HasColumnType("date");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.CodGravacao).HasColumnName("cod_gravacao");

                entity.Property(e => e.Moderador).HasColumnName("moderador");

                entity.HasOne(d => d.CodGravacaoNavigation)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.CodGravacao)
                    .HasConstraintName("participacao_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("participacao_ibfk_1");
            });

            modelBuilder.Entity<Prime>(entity =>
            {
                entity.HasKey(e => e.CodAmazon)
                    .HasName("PRIMARY");

                entity.ToTable("prime");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("cod_usuario");

                entity.Property(e => e.CodAmazon).HasColumnName("cod_amazon");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.LoginAmazon)
                    .IsRequired()
                    .HasColumnName("login_amazon")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SenhaAmazon)
                    .HasColumnName("senha_amazon")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Prime)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prime_ibfk_1");
            });

            modelBuilder.Entity<Recomendacoes>(entity =>
            {
                entity.HasKey(e => new { e.CodUsuario, e.CodCanal })
                    .HasName("PRIMARY");

                entity.ToTable("recomendacoes");

                entity.HasIndex(e => e.CodCanal)
                    .HasName("cod_canal");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.CodCanal).HasColumnName("cod_canal");

                entity.HasOne(d => d.CodCanalNavigation)
                    .WithMany(p => p.RecomendacoesCodCanalNavigation)
                    .HasForeignKey(d => d.CodCanal)
                    .HasConstraintName("recomendacoes_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.RecomendacoesCodUsuarioNavigation)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("recomendacoes_ibfk_1");
            });

            modelBuilder.Entity<Recompensa>(entity =>
            {
                entity.HasKey(e => new { e.CodItem, e.CodAmazon })
                    .HasName("PRIMARY");

                entity.ToTable("recompensa");

                entity.HasIndex(e => e.CodAmazon)
                    .HasName("cod_amazon");

                entity.Property(e => e.CodItem).HasColumnName("cod_item");

                entity.Property(e => e.CodAmazon).HasColumnName("cod_amazon");

                entity.Property(e => e.Recebido).HasColumnName("recebido");

                entity.HasOne(d => d.CodAmazonNavigation)
                    .WithMany(p => p.Recompensa)
                    .HasForeignKey(d => d.CodAmazon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recompensa_ibfk_1");

                entity.HasOne(d => d.CodItemNavigation)
                    .WithMany(p => p.Recompensa)
                    .HasForeignKey(d => d.CodItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recompensa_ibfk_2");
            });

            modelBuilder.Entity<Seguir>(entity =>
            {
                entity.HasKey(e => new { e.CodCanal, e.CodSeguidor })
                    .HasName("PRIMARY");

                entity.ToTable("seguir");

                entity.HasIndex(e => e.CodSeguidor)
                    .HasName("cod_seguidor");

                entity.Property(e => e.CodCanal).HasColumnName("cod_canal");

                entity.Property(e => e.CodSeguidor).HasColumnName("cod_seguidor");

                entity.HasOne(d => d.CodCanalNavigation)
                    .WithMany(p => p.SeguirCodCanalNavigation)
                    .HasForeignKey(d => d.CodCanal)
                    .HasConstraintName("seguir_ibfk_1");

                entity.HasOne(d => d.CodSeguidorNavigation)
                    .WithMany(p => p.SeguirCodSeguidorNavigation)
                    .HasForeignKey(d => d.CodSeguidor)
                    .HasConstraintName("seguir_ibfk_2");
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => new { e.CodUsuario, e.CodCanal })
                    .HasName("PRIMARY");

                entity.ToTable("transacao");

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
                    .HasConstraintName("transacao_ibfk_2");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.TransacaoCodUsuarioNavigation)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("transacao_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
