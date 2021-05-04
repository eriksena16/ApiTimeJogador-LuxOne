using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Models;

namespace ApiTimeJogador_LuxOne.Services
{
    public interface IJogadoresService
    {
        Task<IEnumerable<Jogador>> Get();
        Task<Jogador> GetID(int id);
        Task<Jogador> Salvar(Jogador jogador);
    }
}
