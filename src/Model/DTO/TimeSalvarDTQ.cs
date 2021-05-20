using System;
using System.ComponentModel.DataAnnotations;

namespace LuxOne.Model.DTO
{
    public class TimeSalvarDTQ
    {
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }
    }
}
