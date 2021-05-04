using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTimeJogador_LuxOne.Data;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.Validacao;
using FluentValidation;
using ApiTimeJogador_LuxOne.Iterfaces;

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
        public async Task<ActionResult<IEnumerable<Time>>> Get()
        {
         var times =  await _timesService.Get();
            return Ok(times);
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetID(int id)
        {
            var time = await _timesService.GetID(id);
            

            if (time == null)
            {
                return NotFound();
            }

            return time;
        }


        [HttpPost]
        public async Task<ActionResult<Time>> Salvar(Time time)
        {
            validator.ValidateAndThrow(time);
           await _timesService.Salvar(time);

            return CreatedAtAction("Get", new { id = time.TimeID }, time);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Double>> CalcularMediaIdade(int id)
        {
            var media = await _timesService.CalcularMediaIdade(id);
            return Ok(media) ;
        }

    }
}
