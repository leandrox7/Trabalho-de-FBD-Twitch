using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitch.Models
{
    public class Consulta3
    {
        string nome_streamer;
        string nome_espectador;

        public Consulta3(string nome_streamer, string nome_espectador)
        {
            this.Nome_streamer = nome_streamer;
            this.Nome_espectador = nome_espectador;
        }

        public string Nome_streamer { get => nome_streamer; set => nome_streamer = value; }
        public string Nome_espectador { get => nome_espectador; set => nome_espectador = value; }
    }
}
