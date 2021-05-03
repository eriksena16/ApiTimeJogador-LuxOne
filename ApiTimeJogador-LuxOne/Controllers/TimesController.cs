using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTimeJogador_LuxOne.Data;
using ApiTimeJogador_LuxOne.Models;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("times")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly APIcontext _context;

        public TimesController(APIcontext context)
        {
            _context = context;
        }

        // GET: api/Times
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimes()
        {
            return await _context.Times.ToListAsync();
        }

        // GET: api/Times/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetTime(int id)
        {
            var time = await _context.Times.FindAsync(id);

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
            _context.Times.Add(time);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTime", new { id = time.TimeID }, time);
        }


        private bool TimeExists(int id)
        {
            return _context.Times.Any(e => e.TimeID == id);
        }
    }
}
