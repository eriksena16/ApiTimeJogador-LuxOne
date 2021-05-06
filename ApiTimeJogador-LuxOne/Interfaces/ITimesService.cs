using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTO;
using ApiTimeJogador_LuxOne.Models.DTQ;

namespace ApiTimeJogador_LuxOne.Iterfaces
{
   public interface ITimesService
    {
        Task<List<TimeDTO>>Get();
        Task<Time>Salvar(TimeSalvarDTQ timeSalvarQuery);
        
    }
}
