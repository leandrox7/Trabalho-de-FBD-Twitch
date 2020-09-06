using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Seguir
    {
        public int CodCanal { get; set; }
        public int CodSeguidor { get; set; }

        public virtual Canalstreamer CodCanalNavigation { get; set; }
        public virtual Canalstreamer CodSeguidorNavigation { get; set; }
    }
}
