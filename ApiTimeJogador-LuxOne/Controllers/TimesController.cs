using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTO;
using ApiTimeJogador_LuxOne.Models.DTQ;
using ApiTimeJogador_LuxOne.Models.Validacao;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimesService _timesService;

        private readonly TimeValidator validator = new TimeValidator();

        public TimesController(ITimesService timesService)
        {

            _timesService = timesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TimeDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var times = await _timesService.Get();
            return Ok(times);

        }


        [HttpPost]
        public async Task<ActionResult<Time>> Salvar(TimeSalvarDTQ timeSalvarQuery)
        {
            validator.ValidateAndThrow(timeSalvarQuery);
            Time time = await _timesService.Salvar(timeSalvarQuery);

            return CreatedAtAction("Get", new { id = time.TimeID }, time);
        }
    }
}
