using LuxOne.Model.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuxOne.Contrato.EquipeContrato
{
    public interface ITimeService
    {
        Task<List<TimeDTO>> Get();
        Task<Time> Salvar(TimeSalvarDTQ timeSalvarQuery);
    }
}
