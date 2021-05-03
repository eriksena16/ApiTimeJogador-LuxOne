﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Time
    {
        public int TimeID { get; set; }
        public string Nome { get; set; }
        public DateTime DataInclusao { get; set; }
        public decimal Media = 0;

        ICollection<Jogador> Jogadores { get; set; }
    }
}
