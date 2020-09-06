using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Mensagem
    {
        public string Conteudo { get; set; }
        public int CodGravacao { get; set; }
        public int CodUsuario { get; set; }
        public int IdMensagem { get; set; }

        public virtual Gravacao CodGravacaoNavigation { get; set; }
        public virtual Canalstreamer CodUsuarioNavigation { get; set; }
    }
}
