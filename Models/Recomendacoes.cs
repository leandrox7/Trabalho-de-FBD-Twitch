﻿using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Recomendacoes
    {
        public int CodUsuario { get; set; }
        public int CodCanal { get; set; }

        public virtual Canalstreamer CodCanalNavigation { get; set; }
        public virtual Canalstreamer CodUsuarioNavigation { get; set; }
    }
}
