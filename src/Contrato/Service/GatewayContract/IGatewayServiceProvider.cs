using System;

namespace LuxOne.Contrato.GatewayContract
{
    public interface IGatewayServiceProvider
    {
        T Get<T>();
    }

}
