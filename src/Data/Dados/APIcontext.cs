using LuxOne.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiTimeJogador_LuxOne.Data
{
    public class APIcontext : DbContext
    {
        public APIcontext( DbContextOptions<APIcontext> options) 
            : base(options)
        {
        }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador>Jogadores { get; set; }

    }
}
