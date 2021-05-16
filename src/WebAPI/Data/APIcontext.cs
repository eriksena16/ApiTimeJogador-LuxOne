using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Models;

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
