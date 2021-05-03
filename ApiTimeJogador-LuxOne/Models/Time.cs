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

        [Required]
        [StringLength(10)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataInclusao { get; set; }
        public decimal Media = 0;

        ICollection<Jogador> Jogadores { get; set; }
    }
}
