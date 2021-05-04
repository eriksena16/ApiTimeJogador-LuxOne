using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Services;
using Newtonsoft.Json;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Time
    {
        public int TimeID { get; set; }
  
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }

        [JsonIgnore]
        public double Media { get; set; }

        [JsonIgnore]
       public virtual ICollection<Jogador> Jogadores { get; set; }
    }
}
