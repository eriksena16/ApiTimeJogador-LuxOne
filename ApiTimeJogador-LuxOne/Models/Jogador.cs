using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Jogador
    {
        public int JogadorID { get; set; }
        public string NomeCompleto { get; set; }
        public int Idade { get; set; }
        public int TimeID { get; set; }

        public Time Time { get; set; }
    }
}
