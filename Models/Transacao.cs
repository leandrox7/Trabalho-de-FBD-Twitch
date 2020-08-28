﻿using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Transacao
    {
        public decimal? Valor { get; set; }
        public ulong? Tipo { get; set; }
        public int? Meses { get; set; }
        public int CodUsuario { get; set; }
        public int CodCanal { get; set; }

        public virtual CanalStreamer CodCanalNavigation { get; set; }
        public virtual CanalStreamer CodUsuarioNavigation { get; set; }
    }
}
