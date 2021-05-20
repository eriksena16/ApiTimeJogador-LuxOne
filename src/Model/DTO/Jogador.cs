using Newtonsoft.Json;

namespace LuxOne.Model.DTO
{
    public class Jogador
    {
        public int JogadorID { get; set; }
        
        public string NomeCompleto { get; set; }

        public int Idade { get; set; }

        public int TimeID { get; set; }

        [JsonIgnore]
        public virtual Time Time { get; set; }
    }
}
