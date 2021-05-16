using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTQ;
using LuxOne.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Iterfaces
{
    public interface IJogadoresService
    {
        Task<List<JogadorDTO>> Get();
        Task<IEnumerable<Jogador>> BuscaJogadoresPorTime(int id);
        Task<IEnumerable<Jogador>> BuscaPorIdade(int idade);
        Task<Jogador> Salvar(JogadorSalvarDTQ jogadorSalvarQuery);
    }
}
