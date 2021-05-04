using ApiTimeJogador_LuxOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Data;
using Microsoft.EntityFrameworkCore;
using ApiTimeJogador_LuxOne.Iterfaces;

namespace ApiTimeJogador_LuxOne.Services
{
    public class JogadoresServices : IJogadoresService
    {
        private readonly APIcontext _context;
        public JogadoresServices(APIcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Jogador>> Get()
        {
            return await _context.Jogadores.ToListAsync();
        }

        public async Task<Jogador> GetID(int id)
        {
            var jogador = await _context.Jogadores.FindAsync(id);
            return jogador;
        }

        public async Task<Jogador> Salvar(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            await _context.SaveChangesAsync();
            return await this.GetID(jogador.JogadorID);
        }

         private bool JogadorExists(int id)
        {
            return _context.Jogadores.Any(e => e.JogadorID == id);
        }
    }
}
