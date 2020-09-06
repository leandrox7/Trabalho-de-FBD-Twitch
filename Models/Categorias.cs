using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Categorizados = new HashSet<Categorizados>();
        }

        public int CodCategoria { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Categorizados> Categorizados { get; set; }
    }
}
