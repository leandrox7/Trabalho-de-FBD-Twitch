using System;
using System.Collections.Generic;

namespace Twitch.Models
{
    public partial class Recompensa
    {
        public int CodItem { get; set; }
        public int CodAmazon { get; set; }
        public bool? Recebido { get; set; }

        public virtual Prime CodAmazonNavigation { get; set; }
        public virtual Items CodItemNavigation { get; set; }
    }
}
