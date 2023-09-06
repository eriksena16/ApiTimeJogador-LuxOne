using LuxOne.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace LuxOne.Repository.EquipeRepositoryMemory
{
    public class DbMemoryContext : DbContext
    {
        public DbMemoryContext(DbContextOptions<DbMemoryContext> options)
            : base(options)
        {
        }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
    }
}
