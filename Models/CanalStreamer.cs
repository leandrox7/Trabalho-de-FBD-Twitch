using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class CanalStreamer
    {
        public CanalStreamer()
        {
            DadosPagamento = new HashSet<DadosPagamento>();
            Gravacao = new HashSet<Gravacao>();
            InscritosCodCanalNavigation = new HashSet<Inscritos>();
            InscritosCodUsuarioNavigation = new HashSet<Inscritos>();
            RecomendacoesIdCanalNavigation = new HashSet<Recomendacoes>();
            RecomendacoesIdUsuarioNavigation = new HashSet<Recomendacoes>();
            TransacaoCodCanalNavigation = new HashSet<Transacao>();
            TransacaoCodUsuarioNavigation = new HashSet<Transacao>();
        }

        public string Descricao { get; set; }
        public bool? Online { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int IdUsuario { get; set; }

        public virtual ICollection<DadosPagamento> DadosPagamento { get; set; }
        public virtual ICollection<Gravacao> Gravacao { get; set; }
        public virtual ICollection<Inscritos> InscritosCodCanalNavigation { get; set; }
        public virtual ICollection<Inscritos> InscritosCodUsuarioNavigation { get; set; }
        public virtual ICollection<Recomendacoes> RecomendacoesIdCanalNavigation { get; set; }
        public virtual ICollection<Recomendacoes> RecomendacoesIdUsuarioNavigation { get; set; }
        public virtual ICollection<Transacao> TransacaoCodCanalNavigation { get; set; }
        public virtual ICollection<Transacao> TransacaoCodUsuarioNavigation { get; set; }
    }
}
