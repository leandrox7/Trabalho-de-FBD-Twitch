using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitch.Models
{
    public class Consulta4
    {
        string nome_streamer;
        int total_visualizacoes;

        public Consulta4(string nome_streamer, int total_visualizacoes)
        {
            this.Nome_streamer = nome_streamer;
            this.Total_visualizacoes = total_visualizacoes;
        }

        public string Nome_streamer { get => nome_streamer; set => nome_streamer = value; }
        public int Total_visualizacoes { get => total_visualizacoes; set => total_visualizacoes = value; }
    }
}
