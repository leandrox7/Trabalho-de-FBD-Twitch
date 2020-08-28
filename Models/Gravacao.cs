using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Gravacao
    {
        public int? TotalVisualizacoes { get; set; }
        public TimeSpan? Duracao { get; set; }
        public int? MaxEspectadores { get; set; }
        public int CodTransmissao { get; set; }
        public int CodStreamer { get; set; }

        public virtual CanalStreamer CodStreamerNavigation { get; set; }
    }
}
