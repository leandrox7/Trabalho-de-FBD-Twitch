using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Categorizados
    {
        public int CodGravacao { get; set; }
        public int CodCategoria { get; set; }

        public virtual Categorias CodCategoriaNavigation { get; set; }
        public virtual Gravacao CodGravacaoNavigation { get; set; }
    }
}
