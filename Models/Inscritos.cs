using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Inscritos
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? TotalMeses { get; set; }
        public int CodUsuario { get; set; }
        public int CodCanal { get; set; }

        public virtual CanalStreamer CodCanalNavigation { get; set; }
        public virtual CanalStreamer CodUsuarioNavigation { get; set; }
    }
}
