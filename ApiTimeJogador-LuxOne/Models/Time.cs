using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Time
    {
        public int TimeID { get; set; }
  
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }

       public ICollection<Jogador> Jogadores { get; set; }
    }
}
