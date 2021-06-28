using LuxOne.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuxOne.Contract.EquipeContrato
{
    public interface ITimeService
    {
        Task<List<TimeDTO>> Get();
        Task<Time> Salvar(TimeSalvarDTQ timeSalvarQuery);
    }
}
