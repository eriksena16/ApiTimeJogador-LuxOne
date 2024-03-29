﻿using LuxOne.Contract.EquipeContrato;
using LuxOne.Model.DTO;
using LuxOne.Repository.EquipeRepositoryMemory;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxOne.Service.EquipeService
{
    public class TimeService : ITimeService
    {
        private readonly DbMemoryContext _context;
        public TimeService(DbMemoryContext context) => _context = context;

        public async Task<List<TimeDTO>> Get()
        {
            var todosTimes = _context.Times.Include(_ => _.Jogadores);
            List<TimeDTO> times = new List<TimeDTO>();

            foreach (Time time in todosTimes)
            {

                double? mediaIdade = null;
                List<JogadorDTO> jogadores = new List<JogadorDTO>();
                if (time.Jogadores.Any())
                {
                    mediaIdade = time.Jogadores.Average(_ => _.Idade);

                    foreach (Jogador jogador in time.Jogadores)
                    {
                        JogadorDTO jogadorDTO = new JogadorDTO();

                        jogadorDTO.JogadorID = jogador.JogadorID;
                        jogadorDTO.NomeCompleto = jogador.NomeCompleto;
                        jogadorDTO.Idade = jogador.Idade;
                        jogadorDTO.TimeID = jogador.TimeID;
                        jogadores.Add(jogadorDTO);
                    }
                }

                TimeDTO timeDTO = new TimeDTO();
                timeDTO.TimeID = time.TimeID;
                timeDTO.Nome = time.Nome;
                timeDTO.DataInclusao = time.DataInclusao;
                timeDTO.Jogadores = jogadores;
                timeDTO.MediaIdadeJogadores = mediaIdade;
                times.Add(timeDTO);
            }

            return await Task.FromResult(times);

        }

        public async Task<Time> GetID(int id)
        {
            var time = _context.Times.Include(_ => _.Jogadores).FirstOrDefault(_ => _.TimeID == id);
            return await Task.FromResult(time);
        }

        public async Task<Time> Salvar(TimeSalvarDTQ timeSalvarQuery)
        {
            Time time = new Time();

            time.Nome = timeSalvarQuery.Nome;
            time.DataInclusao = timeSalvarQuery.DataInclusao;

            _context.Times.Add(time);
            await _context.SaveChangesAsync();
            return await this.GetID(time.TimeID);

        }


    }
}
