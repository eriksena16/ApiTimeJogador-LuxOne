using System.Threading.Tasks;

namespace LuxOne.Infrastructure.Contract.InfrastructureContract.Security
{
    public interface IJwtAuthotizationService
    {
        Task<string> Generate();
    }
}
