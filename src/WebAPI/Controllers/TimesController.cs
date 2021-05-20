using ApiTimeJogador_LuxOne.Models.Validacao;
using LuxOne.Contrato.EquipeContrato;
using LuxOne.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class TimesController : ControllerBase
    {
        private readonly ITimeService _timesService;

        private readonly TimeValidator validator = new TimeValidator();

        public TimesController(ITimeService timesService)
        {

            _timesService = timesService;
        }

       
        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<TimeDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            List<TimeDTO> times = await _timesService.Get();
            if (times.Count == 0)
                return NoContent();

            return Ok(times);

        }


        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(Time), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Salvar([FromBody] TimeSalvarDTQ timeSalvarQuery)
        {
            if (timeSalvarQuery is null)
                //bad 12-05
                return BadRequest(timeSalvarQuery);

          //  validator.ValidateAndThrow(timeSalvarQuery);

            Time time = await _timesService.Salvar(timeSalvarQuery);

            return CreatedAtAction("Get", new { id = time.TimeID }, time);
        }
    }
}
