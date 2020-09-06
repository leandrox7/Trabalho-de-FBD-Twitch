using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitch.Models
{
    public class Consulta1
    {
        string nome;
        int itens_reivindicados;

        public Consulta1(string nome, int itens_reivindicados)
        {
            this.Nome = nome;
            this.Itens_reivindicados = itens_reivindicados;
        }

        public string Nome { get => nome; set => nome = value; }
        public int Itens_reivindicados { get => itens_reivindicados; set => itens_reivindicados = value; }
    }
}
