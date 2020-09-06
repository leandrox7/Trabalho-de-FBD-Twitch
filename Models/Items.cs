using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Items
    {
        public Items()
        {
            Recompensa = new HashSet<Recompensa>();
        }

        public int CodItem { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }

        public virtual ICollection<Recompensa> Recompensa { get; set; }
    }
}
