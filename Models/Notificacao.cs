using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Notificacao
    {
        public string Mensagem { get; set; }
        public int IdNotificacao { get; set; }
        public int CodUsuario { get; set; }

        public virtual Canalstreamer CodUsuarioNavigation { get; set; }
    }
}
