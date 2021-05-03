using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Models;

namespace ApiTimeJogador_LuxOne.Services
{
   public interface ITimesService
    {
        Task<IEnumerable<Time>> ToListAsync();
    }
}
