using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Participacao
    {
        public DateTime DataParticipacao { get; set; }
        public int CodUsuario { get; set; }
        public int CodGravacao { get; set; }
        public bool? Moderador { get; set; }

        public virtual Gravacao CodGravacaoNavigation { get; set; }
        public virtual Canalstreamer CodUsuarioNavigation { get; set; }
    }
}
