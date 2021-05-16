using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTQ;

namespace ApiTimeJogador_LuxOne.Iterfaces
{
    public interface ITimesService
    {
        Task<List<TimeDTO>>Get();
        Task<Time>Salvar(TimeSalvarDTQ timeSalvarQuery);
        
    }
}
