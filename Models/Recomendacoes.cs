using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Recomendacoes
    {
        public int IdUsuario { get; set; }
        public int IdCanal { get; set; }

        public virtual CanalStreamer IdCanalNavigation { get; set; }
        public virtual CanalStreamer IdUsuarioNavigation { get; set; }
    }
}
