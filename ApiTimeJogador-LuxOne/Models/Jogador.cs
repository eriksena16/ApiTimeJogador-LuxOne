using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Jogador
    {
        public int JogadorID { get; set; }

        [Required]
        [StringLength(20)]
        public string NomeCompleto { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public Time TimeID { get; set; }
    }
}
