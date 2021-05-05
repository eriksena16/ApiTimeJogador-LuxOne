using ApiTimeJogador_LuxOne.Data;
using ApiTimeJogador_LuxOne.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Models.DTO;

namespace ApiTimeJogador_LuxOne.Services
{
    public class TimesServices : ITimesService
    {
        private readonly APIcontext _context;
        public TimesServices( APIcontext context)
        {
            _context = context;
        }

        public async Task<List<TimeDTO>> Get()
        {

            var todosTimes = _context.Times.Include(_ => _.Jogadores);
            List<TimeDTO> times = new List<TimeDTO>();

            foreach (Time time in todosTimes)
            {
                var mediaIdade = time.Jogadores.Average(_ => _.Idade);
                TimeDTO timeDTO = new TimeDTO();
                timeDTO.TimeID = time.TimeID;
                timeDTO.Nome = time.Nome;
                timeDTO.DataInclusao = time.DataInclusao;
                timeDTO.Jogadores = time.Jogadores;
                timeDTO.MediaIdadeJogadores = mediaIdade;
                times.Add(timeDTO);
            }

            return times;

        }

        public async Task<Time> GetID( int id)
        {
            var time = _context.Times.Include(_ => _.Jogadores).FirstOrDefault(_ => _.TimeID == id);
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
