using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Time
    {
        public int TimeID { get; set; }
  
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }

        ICollection<Jogador> Jogadores { get; set; }
    }
}
