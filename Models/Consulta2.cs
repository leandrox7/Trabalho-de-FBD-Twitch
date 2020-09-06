using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitch.Models
{
    public class Consulta2
    {
        string nome_streamer;
        int total_inscritos;

        public Consulta2(string nome_streamer, int total_inscritos)
        {
            this.Nome_streamer = nome_streamer;
            this.Total_inscritos = total_inscritos;
        }

        public string Nome_streamer { get => nome_streamer; set => nome_streamer = value; }
        public int Total_inscritos { get => total_inscritos; set => total_inscritos = value; }
    }
}
