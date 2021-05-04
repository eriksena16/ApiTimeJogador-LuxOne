using Newtonsoft.Json;

namespace ApiTimeJogador_LuxOne.Models
{
    public class Jogador
    {
        public int JogadorID { get; set; }
        
        public string NomeCompleto { get; set; }

        public int Idade { get; set; }

        public int TimeID { get; set; }

        public Time Time { get; set; }
    }
}
