using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Jogador
    {
        public int JogadorID { get; set; }

        
        public string NomeCompleto { get; set; }

        public int Idade { get; set; }

        
        public int TimeID { get; set; }

        [JsonIgnore]
        public Time Time { get; set; }
    }
}
