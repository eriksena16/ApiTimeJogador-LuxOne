using System;
using System.ComponentModel.DataAnnotations;

namespace ApiTimeJogador_LuxOne.Models.DTQ
{
    public class TimeSalvarDTQ
    {
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }
    }
}
