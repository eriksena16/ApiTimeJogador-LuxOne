using ApiTimeJogador_LuxOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Data;
using Microsoft.EntityFrameworkCore;
using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Models.DTQ;

namespace ApiTimeJogador_LuxOne.Services
{
    public class JogadoresServices : IJogadoresService
    {
        private readonly APIcontext _context;
        public JogadoresServices(APIcontext context) => _context = context;
        public async Task<IEnumerable<Jogador>> Get() => await _context.Jogadores.ToListAsync();

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
