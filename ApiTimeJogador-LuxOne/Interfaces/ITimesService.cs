using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Models;

namespace ApiTimeJogador_LuxOne.Iterfaces
{
   public interface ITimesService
    {
        Task<IEnumerable<Time>>Get();
        Task<Time>GetID(int id);
        Task<Time>Salvar(Time time);
        Task<Double> CalcularMediaIdade(int id);


    }
}
