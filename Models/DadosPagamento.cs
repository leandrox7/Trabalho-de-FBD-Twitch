using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Dadospagamento
    {
        public string Endereco { get; set; }
        public int? NroCartao { get; set; }
        public int? Telefone { get; set; }
        public int CodUsuario { get; set; }
        public int Cpf { get; set; }

        public virtual Canalstreamer CodUsuarioNavigation { get; set; }
    }
}
