using ApiTimeJogador_LuxOne.Code;
using LuxOne.Infrastructure.Contract.InfrastructureContract.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("/api/[controller]/[action]")]
    [AllowAnonymous]
    public class ConnectController : ApplicationController
    {
        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetToken()
        {
            string token = await this.GatewayServiceProvider.Get<IJwtAuthotizationService>().Generate();

            return Ok(token);

        }
    }
}
