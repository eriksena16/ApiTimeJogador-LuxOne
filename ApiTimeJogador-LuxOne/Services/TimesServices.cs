using ApiTimeJogador_LuxOne.Data;
using ApiTimeJogador_LuxOne.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Iterfaces;

namespace ApiTimeJogador_LuxOne.Services
{
    public class TimesServices : ITimesService
    {
        private readonly APIcontext _context;
        public TimesServices( APIcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Time>> Get()
        {
            return await _context.Times.ToListAsync();
        }

        public async Task<Time> GetID( int id)
        {
            var time = await _context.Times.FindAsync(id);
            return time;
        }

        public async Task<Time> Salvar(Time time)
        {

            _context.Times.Add(time);
            await _context.SaveChangesAsync();
            return await this.GetID(time.TimeID);
            
        }

         private bool TimeExists(int id)
        {
            return _context.Times.Any(e => e.TimeID == id);
        }
    }
}
