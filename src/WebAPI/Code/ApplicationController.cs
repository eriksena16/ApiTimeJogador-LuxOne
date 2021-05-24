using LuxOne.Contrato.GatewayContract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
