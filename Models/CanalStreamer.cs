using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Canalstreamer
    {
        public Canalstreamer()
        {
            Dadospagamento = new HashSet<Dadospagamento>();
            Gravacao = new HashSet<Gravacao>();
            InscritosCodCanalNavigation = new HashSet<Inscritos>();
            InscritosCodUsuarioNavigation = new HashSet<Inscritos>();
            Mensagem = new HashSet<Mensagem>();
            Notificacao = new HashSet<Notificacao>();
            Participacao = new HashSet<Participacao>();
            Prime = new HashSet<Prime>();
            RecomendacoesCodCanalNavigation = new HashSet<Recomendacoes>();
            RecomendacoesCodUsuarioNavigation = new HashSet<Recomendacoes>();
            SeguirCodCanalNavigation = new HashSet<Seguir>();
            SeguirCodSeguidorNavigation = new HashSet<Seguir>();
            TransacaoCodCanalNavigation = new HashSet<Transacao>();
            TransacaoCodUsuarioNavigation = new HashSet<Transacao>();
        }

        public string Descricao { get; set; }
        public bool? Online { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int CodUsuario { get; set; }

        public virtual ICollection<Dadospagamento> Dadospagamento { get; set; }
        public virtual ICollection<Gravacao> Gravacao { get; set; }
        public virtual ICollection<Inscritos> InscritosCodCanalNavigation { get; set; }
        public virtual ICollection<Inscritos> InscritosCodUsuarioNavigation { get; set; }
        public virtual ICollection<Mensagem> Mensagem { get; set; }
        public virtual ICollection<Notificacao> Notificacao { get; set; }
        public virtual ICollection<Participacao> Participacao { get; set; }
        public virtual ICollection<Prime> Prime { get; set; }
        public virtual ICollection<Recomendacoes> RecomendacoesCodCanalNavigation { get; set; }
        public virtual ICollection<Recomendacoes> RecomendacoesCodUsuarioNavigation { get; set; }
        public virtual ICollection<Seguir> SeguirCodCanalNavigation { get; set; }
        public virtual ICollection<Seguir> SeguirCodSeguidorNavigation { get; set; }
        public virtual ICollection<Transacao> TransacaoCodCanalNavigation { get; set; }
        public virtual ICollection<Transacao> TransacaoCodUsuarioNavigation { get; set; }
    }
}
