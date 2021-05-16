using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LuxOne.Model.DTO
{
    public class TimeDTO
    {
        public int TimeID { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }

        public double? MediaIdadeJogadores { get; set; }
        public ICollection<JogadorDTO> Jogadores { get; set; }
    }
}
