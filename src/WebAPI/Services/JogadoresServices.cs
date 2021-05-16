using ApiTimeJogador_LuxOne.Data;
using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTQ;
using LuxOne.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Services
{
    public class JogadoresServices : IJogadoresService
    {
        private readonly APIcontext _context;
        public JogadoresServices(APIcontext context) => _context = context;
        public async Task<List<JogadorDTO>> Get()
        {

         var todosJogadores =   _context.Jogadores.Include(_ => _.Time);
            List<JogadorDTO> jogadores = new List<JogadorDTO>();
            foreach (Jogador jogador in todosJogadores)
            {
                JogadorDTO jogadorDTO = new JogadorDTO();
                jogadorDTO.JogadorID = jogador.JogadorID;
                jogadorDTO.NomeCompleto = jogador.NomeCompleto;
                jogadorDTO.Idade = jogador.Idade;
                jogadorDTO.TimeID = jogador.TimeID;
                jogadores.Add(jogadorDTO);
            }

            return jogadores;
        }

        public async Task<Jogador> GetID(int id)
        {
            var jogador =  await _context.Jogadores.FindAsync(id);
            return jogador;
        }
        public async Task<IEnumerable<Jogador>> BuscaJogadoresPorTime(int id) => await _context.Jogadores.Where(_ => string.Equals(Convert.ToString(_.TimeID), Convert.ToString(id), StringComparison.OrdinalIgnoreCase)).ToListAsync();

        public async Task<IEnumerable<Jogador>> BuscaPorIdade(int idade) => await _context.Jogadores.Where(_ => string.Equals(Convert.ToString(_.Idade), Convert.ToString(idade), StringComparison.OrdinalIgnoreCase)).ToListAsync();

        public async Task<Jogador> Salvar(JogadorSalvarDTQ jogadorSalvarQuery)
        {
            Jogador jogador = new Jogador();
            jogador.NomeCompleto = jogadorSalvarQuery.NomeCompleto;
            jogador.Idade = jogadorSalvarQuery.Idade;
            jogador.TimeID = jogadorSalvarQuery.TimeID;

            _context.Jogadores.Add(jogador);
            await _context.SaveChangesAsync();
            return await this.GetID(jogador.JogadorID);
        }

    }
}
