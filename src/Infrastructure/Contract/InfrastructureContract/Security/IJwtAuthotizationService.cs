using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuxOne.Infrastructure.Contract.InfrastructureContract.Security
{
    public interface IJwtAuthotizationService
    {
        Task<string> Generate();
    }
}
