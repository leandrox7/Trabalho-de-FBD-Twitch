using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Prime
    {
        public Prime()
        {
            Recompensa = new HashSet<Recompensa>();
        }

        public string LoginAmazon { get; set; }
        public string SenhaAmazon { get; set; }
        public int CodAmazon { get; set; }
        public int CodUsuario { get; set; }

        public virtual Canalstreamer CodUsuarioNavigation { get; set; }
        public virtual ICollection<Recompensa> Recompensa { get; set; }
    }
}
