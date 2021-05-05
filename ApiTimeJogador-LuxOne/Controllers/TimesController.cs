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
using ApiTimeJogador_LuxOne.Models.DTO;

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
        public async Task<List<TimeDTO>> Get()
        {
         var times =  await _timesService.Get();
            return times;
           
        }


        [HttpPost]
        public async Task<ActionResult<Time>> Salvar(TimeDTO time)
        {
            validator.ValidateAndThrow(time);
           await _timesService.Salvar(time);

            return CreatedAtAction("Get", new { id = time.TimeID }, time);
        }
    }
}
