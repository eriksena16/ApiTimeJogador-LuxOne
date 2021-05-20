using LuxOne.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuxOne.Contrato.EquipeContrato
{
    public interface IJogadoresService
    {
        Task<List<JogadorDTO>> Get();
        Task<IEnumerable<Jogador>> BuscaJogadoresPorTime(int id);
        Task<IEnumerable<Jogador>> BuscaPorIdade(int idade);
        Task<Jogador> Salvar(JogadorSalvarDTQ jogadorSalvarQuery);
    }
}
