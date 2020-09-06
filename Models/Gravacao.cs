using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Gravacao
    {
        public Gravacao()
        {
            Categorizados = new HashSet<Categorizados>();
            Mensagem = new HashSet<Mensagem>();
            Participacao = new HashSet<Participacao>();
        }

        public int? TotalVisualizacoes { get; set; }
        public TimeSpan? Duracao { get; set; }
        public int? MaxEspectadores { get; set; }
        public int CodTransmissao { get; set; }
        public int CodStreamer { get; set; }

        public virtual Canalstreamer CodStreamerNavigation { get; set; }
        public virtual ICollection<Categorizados> Categorizados { get; set; }
        public virtual ICollection<Mensagem> Mensagem { get; set; }
        public virtual ICollection<Participacao> Participacao { get; set; }
    }
}
