using LuxOne.Contract.GatewayContract;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimeJogador_LuxOne.Code
{
    public class ApplicationController : ControllerBase
    {
        private IGatewayServiceProvider _gatewayServiceProvider;

        private IGatewayServiceProvider Create()
        {
            IGatewayServiceProvider gatewayServiceProvider = (IGatewayServiceProvider)this.HttpContext?.RequestServices?.GetService(typeof(IGatewayServiceProvider));

            return gatewayServiceProvider;
        }

        public IGatewayServiceProvider GatewayServiceProvider
        {
            get
            {
                if (_gatewayServiceProvider == null)
                    _gatewayServiceProvider = this.Create();
                return (_gatewayServiceProvider);
            }
        }
    }
}
