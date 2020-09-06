using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitch.Models

{
    public class Consulta5
    {
        private string nome;

        public Consulta5(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get => nome; set => nome = value; }
    }
}
