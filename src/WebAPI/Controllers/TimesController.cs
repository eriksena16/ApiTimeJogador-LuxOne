using ApiTimeJogador_LuxOne.Code;
using LuxOne.Contrato.EquipeContrato;
using LuxOne.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("/api/[controller]/[action]")]
    [Authorize]
    public class TimesController : ApplicationController
    {

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<TimeDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            List<TimeDTO> times = await this.GatewayServiceProvider.Get<ITimeService>().Get();
            if (times.Count == 0)
                return NoContent();

            return Ok(times);

        }


        [HttpPost]
        //[Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(Time), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Salvar([FromBody] TimeSalvarDTQ timeSalvarQuery)
        {
            if (timeSalvarQuery is null)
                //bad 12-05
                return BadRequest(timeSalvarQuery);

            //  validator.ValidateAndThrow(timeSalvarQuery);

            Time time = await this.GatewayServiceProvider.Get<ITimeService>().Salvar(timeSalvarQuery);


            return CreatedAtAction("Get", new { id = time.TimeID }, time);
        }
    }
}
