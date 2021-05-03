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
using ApiTimeJogador_LuxOne.Services;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimesService _timesService;
        
        private TimeValidator validator = new TimeValidator();

        public TimesController(APIcontext context, ITimesService timesService)
        {
            
            _timesService = timesService;
        }

        // GET: api/Times
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimes()
        {
         var times =  await _timesService.Get();
            return Ok(times);
           
        }

        // GET: api/Times/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetTime(int id)
        {
            var time = await _timesService.GetID(id);
            

            if (time == null)
            {
                return NotFound();
            }

            return time;
        }


        // POST: api/Times
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Time>> PostTime(Time time)
        {
            validator.ValidateAndThrow(time);
           await _timesService.Salvar(time);

            return CreatedAtAction("GetTime", new { id = time.TimeID }, time);
        }


       /* private bool TimeExists(int id)
        {
            return _context.Times.Any(e => e.TimeID == id);
        }*/
    }
}
