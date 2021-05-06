using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTO;
using ApiTimeJogador_LuxOne.Models.DTQ;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Iterfaces
{
    public interface ITimesService
    {
        Task<List<TimeDTO>>Get();
        Task<Time>Salvar(TimeSalvarDTQ timeSalvarQuery);
        
    }
}
